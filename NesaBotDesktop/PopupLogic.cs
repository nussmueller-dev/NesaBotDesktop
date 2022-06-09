namespace NesaBotDesktop {
  public static class PopupLogic {
    public static void ShowErrorMessage(string message, string title = "") {
      MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void ShowWarningMessage(string message, string title = "") {
      MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public static void ShowInfoMessage(string message, string title = "") {
      MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
  }
}
