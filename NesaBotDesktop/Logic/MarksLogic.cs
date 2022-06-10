using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NesaBotDesktop.Logic {
  internal class MarksLogic {
    private static readonly string _clientId = "cj79FSz1JQvZKpJY";
    private static readonly string _state = "wiesoChanMerEigentlichDeScheissLäärLohFrogezeiche";
    private static readonly string _urlRegex = @"[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";
    private static readonly int _timeout = 2000;

    private static RestClient _restClient = new RestClient();

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

    private static string GetToken(string username, string password, string url) {
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

      if (response.ResponseUri!.AbsoluteUri.Contains("access_token")) {
        var accessTokenIndex = response.ResponseUri.AbsoluteUri.IndexOf("access_token");
        var accessTokenEndIndex = response.ResponseUri.AbsoluteUri.IndexOf("&", accessTokenIndex);
        accessTokenIndex += 13;
        var token = response.ResponseUri.AbsoluteUri.Substring(accessTokenIndex, accessTokenEndIndex - accessTokenIndex);
        return token;
      }

      return "";
    }

    private static string GetLoginHash(string url) {
      url = NormalizeUrl(url);
      RestResponse response;

      try {
        var uri = new Uri($"{url}authorize.php?response_type=token&client_id={_clientId}&state={_state}");
        var request = new RestRequest(uri, Method.Get);
        request.Timeout = _timeout;
        response = _restClient.Execute(request);
      } catch (Exception e) {
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

    private static string NormalizeUrl(string url) {
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
  }
}
