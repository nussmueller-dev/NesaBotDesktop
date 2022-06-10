using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesaBotDesktop.Logic {
  internal class UtilLogic {
    internal static async void DoDefaultStuff() {
      if (Properties.ApplicationSettings.Default.EnableDiscordBot && await DiscordLogic.IsTokenValid(Properties.ApplicationSettings.Default.DiscordBotToken)) {
        DiscordLogic.Start(Properties.ApplicationSettings.Default.DiscordBotToken);
      }

      if (MarksLogic.IsLoginValid(Properties.NesaSettings.Default.URL, Properties.NesaSettings.Default.Username, Properties.NesaSettings.Default.Password)) {
        MarksLogic.StartMainLoop();
      }
    }

    internal static void CheckSettingsForNull() {
      if (Properties.DiscordSettings.Default.InformedMarks is null) {
        Properties.DiscordSettings.Default.InformedMarks = new System.Collections.Specialized.StringCollection();
      }

      if (Properties.ApplicationSettings.Default.PushNotificationsInformedMarks is null) {
        Properties.ApplicationSettings.Default.PushNotificationsInformedMarks = new System.Collections.Specialized.StringCollection();
      }

      if (Properties.DiscordSettings.Default.DmUsers is null) {
        Properties.DiscordSettings.Default.DmUsers = new System.Collections.Specialized.StringCollection();
      }

      if (Properties.DiscordSettings.Default.JoinedChanels is null) {
        Properties.DiscordSettings.Default.JoinedChanels = new System.Collections.Specialized.StringCollection();
      }
    }
  }
}
