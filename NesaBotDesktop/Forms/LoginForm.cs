using NesaBotDesktop.Logic;

namespace NesaBotDesktop {
  public partial class LoginForm : Form {
    public LoginForm() {
      InitializeComponent();
    }

    private void LoginForm_Load(object sender, EventArgs e) {
      tb_url.Text = Properties.NesaSettings.Default.URL;
      tb_username.Text = Properties.NesaSettings.Default.Username;
      tb_password.Text = Properties.NesaSettings.Default.Password;
    }

    private void btn_cancel_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void btn_safe_Click(object sender, EventArgs e) {
      if (!MarksLogic.IsInternetAvailable()) {
        PopupLogic.ShowErrorMessage("Bitte stelle zuerst eine Internetverbindung her", "Keine Internetverbindung");
        return;
      }

      var url = tb_url.Text.Trim();
      var username = tb_username.Text;
      var password = tb_password.Text;
      var isEveryInputFilled = true;

      pb_errorArrowUrl.Visible = false;
      pb_errorArrowUsername.Visible = false;
      pb_errorArrowPassword.Visible = false;

      if (url.Length == 0) {
        pb_errorArrowUrl.Visible = true;
        isEveryInputFilled = false;
      }

      if (username.Length == 0) {
        pb_errorArrowUsername.Visible = true;
        isEveryInputFilled = false;
      }

      if (password.Length == 0) {
        pb_errorArrowPassword.Visible = true;
        isEveryInputFilled = false;
      }

      if (!isEveryInputFilled) {
        PopupLogic.ShowErrorMessage("Bitte alle Felder ausfüllen", "Invalide Eingabe");
        return;
      }

      if (!MarksLogic.IsUrlValid(url)) {
        PopupLogic.ShowErrorMessage("Die URL ist ungültig", "Invalide Eingabe");
        pb_errorArrowUrl.Visible = true;
        return;
      }

      if (!MarksLogic.IsLoginValid(url, username, password)) {
        PopupLogic.ShowErrorMessage("Die Logindaten sind ungültig", "Invalide Eingabe");
        pb_errorArrowUsername.Visible = true;
        pb_errorArrowPassword.Visible = true;
        return;
      }

      Properties.NesaSettings.Default.URL = MarksLogic.NormalizeUrl(url);
      Properties.NesaSettings.Default.Username = username;
      Properties.NesaSettings.Default.Password = password;

      Properties.NesaSettings.Default.Save();

      Close();
    }
  }
}
