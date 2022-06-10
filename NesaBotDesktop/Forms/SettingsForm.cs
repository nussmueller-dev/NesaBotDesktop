using Microsoft.Win32;

namespace NesaBotDesktop {
  public partial class SettingsForm : Form {
    private static readonly string _startupRegistryKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
    private static readonly string _startupRegistryKeyValue = "NesaBot";

    public SettingsForm() {
      InitializeComponent();
    }

    private void SettingsForm_Load(object sender, EventArgs e) {
      ns_interval.Value = Properties.ApplicationSettings.Default.Interval;
      cb_autostart.Checked = Properties.ApplicationSettings.Default.Autostart;
      cb_pushNotifications.Checked = Properties.ApplicationSettings.Default.PushNotifications;
      cb_activateDiscordBot.Checked = Properties.ApplicationSettings.Default.EnableDiscordBot;
      tb_botToken.Text = Properties.ApplicationSettings.Default.DiscordBotToken;
    }

    private void cb_activateDiscordBot_CheckedChanged(object sender, EventArgs e) {
      tb_botToken.Enabled = cb_activateDiscordBot.Checked;
    }

    private void Save() {
      RegistryKey? key = Registry.CurrentUser.OpenSubKey(_startupRegistryKey, true);
      try {
        if (cb_autostart.Checked) {
          key?.SetValue(_startupRegistryKeyValue, Application.ExecutablePath.ToString());
        } else {
          key?.DeleteValue(_startupRegistryKeyValue);
        }
      } catch { }

      Properties.ApplicationSettings.Default.Interval = (int)ns_interval.Value;
      Properties.ApplicationSettings.Default.Autostart = cb_autostart.Checked;
      Properties.ApplicationSettings.Default.PushNotifications = cb_pushNotifications.Checked;
      Properties.ApplicationSettings.Default.EnableDiscordBot = cb_activateDiscordBot.Checked;
      Properties.ApplicationSettings.Default.DiscordBotToken = tb_botToken.Text;
    }
  }
}
