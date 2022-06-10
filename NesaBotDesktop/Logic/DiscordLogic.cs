using Discord;
using Discord.WebSocket;

namespace NesaBotDesktop.Logic {
  internal static class DiscordLogic {
    private static readonly string _commandPrefix = "!nesa ";

    private static DiscordSocketClient _client;
    private static Task? _mainTask;
    private static bool _isStarted = false;

    public static async Task<bool> IsTokenValid(string token) {
      if (_isStarted) {
        await Stop();
        _isStarted = false;
      }

      _client = new DiscordSocketClient();

      try {
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.GetApplicationInfoAsync();

        return true;
      } catch {
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

    public static void NewMark(string subjectName) {
      if (_isStarted) {
        
      }
    }

    private static async Task MainAsync(string token) {
      _client = new DiscordSocketClient();
      _client.Log += Log;
      _client.MessageReceived += HandleCommandAsync;

      await _client.LoginAsync(TokenType.Bot, token);
      await _client.StartAsync();

      await Task.Delay(-1);
    }

    private static async Task HandleCommandAsync(SocketMessage messageParam) {
      var message = messageParam as SocketUserMessage;
      if (message == null || message.Author.IsBot || !message.Content.StartsWith(_commandPrefix)) return;

      var command = message.Content.Substring(_commandPrefix.Length, message.Content.Length - _commandPrefix.Length).ToLower();

      switch (command) {
        case "join":
          Join(message);
          break;
        case "leave":
          Leave(message);
          break;
        case "dm":
          DM(message);
          break;
        case "stop dm":
          StopDM(message);
          break;
      }
    }

    private static async void Join(SocketUserMessage message) {
      if (Properties.DiscordSettings.Default.JoinedChanels is null) {
        Properties.DiscordSettings.Default.JoinedChanels = new System.Collections.Specialized.StringCollection();
      }

      if (Properties.DiscordSettings.Default.JoinedChanels.Contains(message.Channel.Id.ToString())) {
        await message.ReplyAsync("Wie ich bereits erwähnt hatte, werde ich euch hier über neue Noten informieren");
      } else {
        Properties.DiscordSettings.Default.JoinedChanels.Add(message.Channel.Id.ToString());
        Properties.DiscordSettings.Default.Save();

        await message.ReplyAsync("Hallo, ich werde in Zukunft eine Nachricht in diesem Chanel hinterlassen, wenn neue Noten verfügbar sind");
      }
    }

    private static async void Leave(SocketUserMessage message) {
      if (Properties.DiscordSettings.Default.JoinedChanels is null) {
        Properties.DiscordSettings.Default.JoinedChanels = new System.Collections.Specialized.StringCollection();
      }

      if (Properties.DiscordSettings.Default.JoinedChanels.Contains(message.Channel.Id.ToString())) {
        Properties.DiscordSettings.Default.JoinedChanels.Remove(message.Channel.Id.ToString());
        Properties.DiscordSettings.Default.Save();

        var response = await message.ReplyAsync("Ich werde von nun an nicht mehr über diesen Chanel informieren");

        var sadEmoji = new Emoji("😭");
        await response.AddReactionAsync(sadEmoji);
      } else {
        await message.ReplyAsync("Ich hatte nie vor euch hier zu informieren");
      }
    }

    private static async void DM(SocketUserMessage message) {
      if (Properties.DiscordSettings.Default.DmUsers is null) {
        Properties.DiscordSettings.Default.DmUsers = new System.Collections.Specialized.StringCollection();
      }

      if (Properties.DiscordSettings.Default.DmUsers.Contains(message.Author.Id.ToString())) {
        await message.ReplyAsync("Wie ich bereits erwähnt hatte, werde ich dich auch persönlich über neue Noten informieren");
      } else {
        Properties.DiscordSettings.Default.DmUsers.Add(message.Author.Id.ToString());
        Properties.DiscordSettings.Default.Save();

        await message.ReplyAsync("Ich werde dich in Zukunft auch persönlich über neue Noten informieren");
      }
    }

    private static async void StopDM(SocketUserMessage message) {
      if (Properties.DiscordSettings.Default.DmUsers is null) {
        Properties.DiscordSettings.Default.DmUsers = new System.Collections.Specialized.StringCollection();
      }

      if (Properties.DiscordSettings.Default.DmUsers.Contains(message.Author.Id.ToString())) {
        Properties.DiscordSettings.Default.DmUsers.Remove(message.Author.Id.ToString());
        Properties.DiscordSettings.Default.Save();

        await message.ReplyAsync("Ich werde dich von nun an nicht mehr persönlich informieren");
      } else {
        await message.ReplyAsync("Ich war schon immer zu faul um dich persönlich zu informieren");
      }
    }

    private static Task Log(LogMessage msg) {
      Console.WriteLine(msg.ToString());
      return Task.CompletedTask;
    }
  }
}
