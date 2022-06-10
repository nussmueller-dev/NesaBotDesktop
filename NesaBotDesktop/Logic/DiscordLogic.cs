using Discord;
using Discord.WebSocket;

namespace NesaBotDesktop.Logic {
  internal static class DiscordLogic {
    private static DiscordSocketClient _client;
    private static Task? _mainTask;
    private static bool _isStarted = false;

    public static async Task<bool> CheckToken(string token) {
      if (_isStarted) {
        await Stop();
      }

      try{
        await _client.LoginAsync(TokenType.Bot, token);

        return true;
      }catch{
        return false;
      }
    }

    public static void Start(string token) {
      if (!_isStarted) {
        _mainTask = Task.Run(() => MainAsync(token));
        _isStarted = true;
      }
    }

    public static async Task Stop() {
      if (_isStarted) {
        await _client.StopAsync();
        _mainTask?.Dispose();

        _isStarted = false;
      }
    }

    private static async Task MainAsync(string token) {
      _client = new DiscordSocketClient();
      _client.Log += Log;

      await _client.LoginAsync(TokenType.Bot, token);
      await _client.StartAsync();

      await Task.Delay(-1);
    }

    private static Task Log(LogMessage msg) {
      Console.WriteLine(msg.ToString());
      return Task.CompletedTask;
    }
  }
}
