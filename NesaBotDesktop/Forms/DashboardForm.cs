using NesaBotDesktop.Logic;

namespace NesaBotDesktop.Forms {
  public partial class DashboardForm : Form {
    public DashboardForm() {
      InitializeComponent();
    }

    private void DashboardForm_Load(object sender, EventArgs e) {

    }

    private void pb_account_Click(object sender, EventArgs e) {
      var loginForm = new LoginForm();

      if (Application.OpenForms.OfType<LoginForm>().Count() == 0) {
        loginForm.ShowDialog();
      } 
    }

    private void pb_settings_Click(object sender, EventArgs e) {
      var settingsForm = new SettingsForm();

      if (Application.OpenForms.OfType<SettingsForm>().Count() == 0) {
        settingsForm.ShowDialog();
      } 
    }
  }
}
