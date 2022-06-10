using NesaBotDesktop.Logic;

namespace NesaBotDesktop.Forms {
  public partial class DashboardForm : Form {
    public DashboardForm() {
      InitializeComponent();
    }

    private void DashboardForm_Load(object sender, EventArgs e) {
      var settingsForm = new SettingsForm();
      settingsForm.ShowDialog(this);

      if (settingsForm.DialogResult == DialogResult.Cancel) {
        Close();
        return;
      }

      DiscordLogic.Start(Properties.ApplicationSettings.Default.DiscordBotToken);
    }
  }
}
