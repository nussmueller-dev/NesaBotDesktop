using NesaBotDesktop.Logic;
using System.Reflection;

namespace NesaBotDesktop.Forms {
  public partial class DashboardForm : Form {
    public DashboardForm() {
      InitializeComponent();
    }

    private void DashboardForm_Load(object sender, EventArgs e) {
      Icon = UtilLogic.GetAppIcon();
      RefreshView();
    }

    private void pb_account_Click(object sender, EventArgs e) {
      var loginForm = new LoginForm();

      if (Application.OpenForms.OfType<LoginForm>().Count() == 0) {
        loginForm.ShowDialog();
        RefreshView();
        UtilLogic.DoDefaultStuff();
      } 
    }

    private void pb_settings_Click(object sender, EventArgs e) {
      var settingsForm = new SettingsForm();

      if (Application.OpenForms.OfType<SettingsForm>().Count() == 0) {
        settingsForm.ShowDialog();
        RefreshView();
        UtilLogic.DoDefaultStuff();
      } 
    }

    private void RefreshView() {
      if (Properties.ApplicationSettings.Default.EnableDiscordBot) {
        pb_meme.Image = Properties.Resources.Teacher;
        pa_discordCommands.Visible = true;
      } else {
        pb_meme.Image = Properties.Resources.meme01;
        pa_discordCommands.Visible = false;
      }
    }
  }
}
