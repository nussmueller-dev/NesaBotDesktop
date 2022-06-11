using Microsoft.Win32;
using NesaBotDesktop.Logic;
using System.Reflection;

namespace NesaBotDesktop {
  public partial class SettingsForm : Form {
    private static readonly string _startupRegistryKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
    private static readonly string _startupRegistryKeyValue = "NesaBot";

    public SettingsForm() {
      InitializeComponent();
    }

    private void SettingsForm_Load(object sender, EventArgs e) {
      Icon = UtilLogic.GetAppIcon();

      ns_interval.Value = Properties.ApplicationSettings.Default.Interval;
      cb_autostart.Checked = Properties.ApplicationSettings.Default.Autostart;
      cb_pushNotifications.Checked = Properties.ApplicationSettings.Default.PushNotifications;
      cb_activateDiscordBot.Checked = Properties.ApplicationSettings.Default.EnableDiscordBot;
      tb_botToken.Text = Properties.ApplicationSettings.Default.DiscordBotToken;
    }

    private void cb_activateDiscordBot_CheckedChanged(object sender, EventArgs e) {
      tb_botToken.Enabled = cb_activateDiscordBot.Checked;
      lb_botToken.Enabled = cb_activateDiscordBot.Checked;
    }

    private async void btn_save_Click(object sender, EventArgs e) {
      if (cb_activateDiscordBot.Checked && !await DiscordLogic.IsTokenValid(tb_botToken.Text)) {
        PopupLogic.ShowErrorMessage("Der Token ist ungültig", "Ungültiger Token");
        return;
      }

#if (!DEBUG)
      RegistryKey? key = Registry.CurrentUser.OpenSubKey(_startupRegistryKey, true);
      try {
        if (cb_autostart.Checked) {
          key?.SetValue(_startupRegistryKeyValue, Application.ExecutablePath.ToString());
        } else {
          key?.DeleteValue(_startupRegistryKeyValue);
        }
      } catch { }
#endif

      Properties.ApplicationSettings.Default.Interval = (int)ns_interval.Value;
      Properties.ApplicationSettings.Default.Autostart = cb_autostart.Checked;
      Properties.ApplicationSettings.Default.PushNotifications = cb_pushNotifications.Checked;
      Properties.ApplicationSettings.Default.EnableDiscordBot = cb_activateDiscordBot.Checked;
      Properties.ApplicationSettings.Default.DiscordBotToken = tb_botToken.Text;
      Properties.ApplicationSettings.Default.Save();

      DialogResult = DialogResult.OK;
      Close();
    }

    private void btn_cancel_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Cancel;
      Close();
    }
  }
}
