using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NesaBotDesktop {
  internal class MarksLogic {
    private static readonly string _clientId = "cj79FSz1JQvZKpJY";
    private static readonly string _state = "wiesoChanMerEigentlichDeScheissLäärLohFrogezeiche";

    private static RestClient _restClient = new RestClient();
    private string _nesaUrl;

    public MarksLogic(string nesaUrl) {
      if (nesaUrl.EndsWith("/")) {
        _nesaUrl = nesaUrl;
      } else {
        _nesaUrl = nesaUrl + "/";
      }
    }

    internal static bool IsUrlValid(string url) {
      var loginHash = GetLoginHash(url);

      return loginHash.Length > 0;
    }

    internal static bool IsLoginValid(string url, string username, string password) {
      var token = GetToken(username, password, url);

      return token.Length > 0;
    }

    private static string GetToken(string username, string password, string url) {
      var loginHash = GetLoginHash(url);

      var uri = new Uri($"{url}authorize.php?response_type=token&client_id={_clientId}&state={_state}&redirect_uri=https://www.schul-netz.com/mobile/oauth-callback.html");
      var request = new RestRequest(uri, Method.Post);
      request.AlwaysMultipartFormData = true;
      request.AddParameter("login", username);
      request.AddParameter("passwort", password);
      request.AddParameter("loginhash", loginHash);
      RestResponse response = _restClient.Execute(request);

      if (!response.IsSuccessful) {
        return "";
      }

      if (response.ResponseUri.AbsoluteUri.Contains("access_token")) {
        var accessTokenIndex = response.ResponseUri.AbsoluteUri.IndexOf("access_token");
        var accessTokenEndIndex = response.ResponseUri.AbsoluteUri.IndexOf("&", accessTokenIndex);
        accessTokenIndex += 13;
        var token = response.ResponseUri.AbsoluteUri.Substring(accessTokenIndex, accessTokenEndIndex - accessTokenIndex);
        return token;
      }

      return "";
    }

    private static string GetLoginHash(string url) {
      var uri = new Uri($"{url}authorize.php?response_type=token&client_id={_clientId}&state={_state}");
      var request = new RestRequest(uri, Method.Get);
      RestResponse response = _restClient.Execute(request);

      if (!response.IsSuccessful) {
        return "";
      }

      if (response.Content.Contains("loginhash")) {
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
