namespace NesaBotDesktop.Forms {
  public partial class DashboardForm : Form {
    public DashboardForm() {
      InitializeComponent();
    }

    private void DashboardForm_Load(object sender, EventArgs e) {
      var loginForm = new SettingsForm();
      loginForm.ShowDialog(this);

      if (loginForm.DialogResult == DialogResult.Cancel) {
        Close();
      }
    }
  }
}
