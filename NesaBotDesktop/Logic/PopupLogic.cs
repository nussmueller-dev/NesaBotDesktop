namespace NesaBotDesktop.Logic {
  public static class PopupLogic {
    public static NotifyIcon? TrayIcon { get; set; }

    public static void ShowErrorMessage(string message, string title = "") {
      MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void ShowWarningMessage(string message, string title = "") {
      MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public static void ShowInfoMessage(string message, string title = "") {
      MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void ShowPushNotification(string message, string title) {
      TrayIcon?.ShowBalloonTip(1000, title, message, ToolTipIcon.Info);
    }
  }
}
