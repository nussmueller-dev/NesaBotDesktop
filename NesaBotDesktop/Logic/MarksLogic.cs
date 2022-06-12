using NesaBotDesktop.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text.RegularExpressions;

namespace NesaBotDesktop.Logic {
  internal class MarksLogic {
    private static readonly string _clientId = "cj79FSz1JQvZKpJY";
    private static readonly string _state = "wiesoChanMerEigentlichDeScheissLäärLohFrogezeiche";
    private static readonly string _urlRegex = @"[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";
    private static readonly int _timeout = 2000;
    private static readonly RestClient _restClient = new RestClient();

    private static Task? _mainTask;
    private static bool _mainTaskIsStarted = false;
    private static string _token = "";

    internal static bool IsLoginValid(string url, string username, string password) {
      if (!IsUrlValid(url)) {
        return false;
      }

      var token = GetToken(username, password, url);

      return token.Length > 0;
    }

    internal static bool IsUrlValid(string url) {
      Regex rgx = new Regex(_urlRegex, RegexOptions.Compiled);

      if (!rgx.IsMatch(url)) {
        return false;
      }

      var loginHash = GetLoginHash(url);

      return loginHash.Length > 0;
    }

    internal static bool IsInternetAvailable() {
      var uri = new Uri("https://google.com/");
      var request = new RestRequest(uri, Method.Get);
      request.Timeout = _timeout;
      RestResponse response = _restClient.Execute(request);

      return response.IsSuccessful;
    }

    internal static void StartMainLoop() {
      if (_mainTaskIsStarted) {
        StopMainLoop();
      }

      _token = GetToken(Properties.NesaSettings.Default.Username, Properties.NesaSettings.Default.Password, Properties.NesaSettings.Default.URL);

      _mainTask = Task.Run(() => MainAsync());
      _mainTaskIsStarted = true;
    }

    internal static void StopMainLoop() {
      try {
        _mainTask?.Dispose();
      } catch { }

      _mainTaskIsStarted = false;
    }

    internal static string NormalizeUrl(string url) {
      if (!url.EndsWith("/")) {
        url += "/";
      }

      if (!(url.StartsWith("https://") || url.StartsWith("http://"))) {
        url = "https://" + url;
      }

      if (url.StartsWith("http://")) {
        url = url.Replace("http://", "https://");
      }

      var lastSlashIndex = 0;

      for (int i = 0; i < 3; i++) {
        lastSlashIndex = url.IndexOf("/", lastSlashIndex + 1);
      }

      url = url.Substring(0, lastSlashIndex + 1);

      return url;
    }

    private static void MainAsync() {
      while (_mainTaskIsStarted) {
        var marks = GetMarks();

        if (marks is null) {
          Thread.Sleep(300000); //5min
          continue;
        }

        if (Properties.ApplicationSettings.Default.EnableDiscordBot) {
          UtilLogic.CheckSettingsForNull();
          foreach (var mark in marks.Where(x => !Properties.DiscordSettings.Default.InformedMarks.Contains(x.Id))) {
            DiscordLogic.NewMark(mark);
          }
        }

        UtilLogic.CheckSettingsForNull();
        if (Properties.ApplicationSettings.Default.PushNotifications && marks.Any(x => !Properties.ApplicationSettings.Default.PushNotificationsInformedMarks.Contains(x.Id))) {
          PopupLogic.ShowPushNotification("Neue Noten verfügbar", "Es wurden neue Noten veröffentlicht, schau doch mal vorbei");

          foreach (var mark in marks.Where(x => !Properties.ApplicationSettings.Default.PushNotificationsInformedMarks.Contains(x.Id))) {
            Properties.ApplicationSettings.Default.PushNotificationsInformedMarks.Add(mark.Id);
          }

          Properties.ApplicationSettings.Default.Save();
        }

        Thread.Sleep(Properties.ApplicationSettings.Default.Interval * 60000);
      }
    }

    private static List<MarkModel> GetMarks() {
      var uri = new Uri($"{Properties.NesaSettings.Default.URL}rest/v1/me/grades");
      var request = new RestRequest(uri, Method.Get);
      request.Timeout = _timeout;
      request.AddHeader("Authorization", $"Bearer {_token}");
      RestResponse response = _restClient.Execute(request);

      if (response.StatusCode == HttpStatusCode.OK && response.Content != null) {
        return JsonConvert.DeserializeObject<List<MarkModel>>(response.Content);
      } else if (response.StatusCode == HttpStatusCode.Unauthorized) {
        _token = GetToken(Properties.NesaSettings.Default.Username, Properties.NesaSettings.Default.Password, Properties.NesaSettings.Default.URL);
        return null;
      } else {
        return null;
      }
    }

    private static string GetToken(string username, string password, string url, bool firstTry = true) {
      url = NormalizeUrl(url);
      var loginHash = GetLoginHash(url);

      var uri = new Uri($"{url}authorize.php?response_type=token&client_id={_clientId}&state={_state}&redirect_uri=https://www.schul-netz.com/mobile/oauth-callback.html");
      var request = new RestRequest(uri, Method.Post);
      request.Timeout = _timeout;
      request.AlwaysMultipartFormData = true;
      request.AddParameter("login", username);
      request.AddParameter("passwort", password);
      request.AddParameter("loginhash", loginHash);
      RestResponse response = _restClient.Execute(request);

      if (!response.IsSuccessful) {
        return "";
      }

      if (response.Content != null 
        && response.Content.Contains("Externe Anbindung") 
        && response.Content.Contains("Erlauben") 
        && response.Content.Contains("Verweigern")
      ) {
        response = AcceptThirdPartyApp(uri, response.Content);

        if (response is null) {
          return "";
        }
      }

      if (response.ResponseUri!.AbsoluteUri.Contains("access_token")) {
        var accessTokenIndex = response.ResponseUri.AbsoluteUri.IndexOf("access_token");
        var accessTokenEndIndex = response.ResponseUri.AbsoluteUri.IndexOf("&", accessTokenIndex);
        accessTokenIndex += 13;
        var token = response.ResponseUri.AbsoluteUri.Substring(accessTokenIndex, accessTokenEndIndex - accessTokenIndex);
        return token;
      }

      return "";
    }

    private static RestResponse AcceptThirdPartyApp(Uri uri, string responseContent) {
      if (responseContent.Contains("form method='post'")) {
        var formIndex = responseContent.IndexOf("form method='post'");
        var formCloseIndex = responseContent.IndexOf(">", formIndex);
        var actionIndex = responseContent.LastIndexOf("action", formCloseIndex);
        var actionStartIndex = responseContent.IndexOf("'", actionIndex);
        var actionEndIndex = responseContent.IndexOf("'", actionIndex + 9);

        var wholeUrl = responseContent.Substring(actionStartIndex + 1, actionEndIndex - actionStartIndex - 1);
        var idIndex = wholeUrl.LastIndexOf("id=");
        var idText = wholeUrl.Substring(idIndex, wholeUrl.Length - idIndex);

        uri = new Uri(uri.AbsoluteUri + "&" + idText);
      } else {
        return null;
      }

      var request = new RestRequest(uri, Method.Post);
      request.Timeout = _timeout;
      request.AlwaysMultipartFormData = true;
      request.AddParameter("authorized", "yes");
      return _restClient.Execute(request);
    }

    private static string GetLoginHash(string url) {
      url = NormalizeUrl(url);
      RestResponse response;

      try {
        var uri = new Uri($"{url}authorize.php?response_type=token&client_id={_clientId}&state={_state}");
        var request = new RestRequest(uri, Method.Get);
        request.Timeout = _timeout;
        response = _restClient.Execute(request);
      } catch {
        return "";
      }

      if (!response.IsSuccessful) {
        return "";
      }

      if (response.Content!.Contains("loginhash")) {
        var loginHashIndex = response.Content.IndexOf("loginhash");
        var loginHashCloseIndex = response.Content.IndexOf(">", loginHashIndex);
        var valueIndex = response.Content.LastIndexOf("value", loginHashCloseIndex);
        var valueStartIndex = response.Content.IndexOf("'", valueIndex);
        var valueEndIndex = response.Content.IndexOf("'", valueIndex + 8);

        var loginhash = response.Content.Substring(valueStartIndex + 1, valueEndIndex - valueStartIndex - 1);
        return loginhash;
      }

      return "";
    }
  }
}
