using NesaBotDesktop.Forms;
using NesaBotDesktop.Logic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

namespace NesaBotDesktop {
  internal static class Program {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      var otherProcess = PriorProcess();
      if (otherProcess != null) {
        otherProcess.Kill();
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      ApplicationConfiguration.Initialize();
      Application.Run(new NesaBotApplicationContext());
    }

    public static Process? PriorProcess() {
      Process curr = Process.GetCurrentProcess();
      Process[] procs = Process.GetProcessesByName(curr.ProcessName);
      foreach (Process p in procs) {
        if ((p.Id != curr.Id) &&
            (p.MainModule!.FileName == curr.MainModule!.FileName))
          return p;
      }
      return null!;
    }
  }

  internal class NesaBotApplicationContext : ApplicationContext {
    private NotifyIcon trayIcon;
    private ContextMenuStrip contextMenu;
    private DashboardForm dashboardForm = new DashboardForm();
    private LoginForm loginForm = new LoginForm();
    private SettingsForm settingsForm = new SettingsForm();

    public NesaBotApplicationContext() {
      if (!MarksLogic.IsLoginValid(Properties.NesaSettings.Default.URL, Properties.NesaSettings.Default.Username, Properties.NesaSettings.Default.Password)) {
        loginForm.ShowDialog();

        if (loginForm.DialogResult != DialogResult.OK) {
          Environment.Exit(0);
          return;
        }
      }

      if (!Properties.ApplicationSettings.Default.InitalSettingsSet) {
        settingsForm.ShowDialog();

        if (settingsForm.DialogResult == DialogResult.OK) {
          Properties.ApplicationSettings.Default.InitalSettingsSet = true;
          Properties.ApplicationSettings.Default.Save();
        } else {
          Environment.Exit(0);
          return;
        }
      }

      contextMenu = new ContextMenuStrip {};

      var dashboardItem = new ToolStripMenuItem() {
        Text = "Dashboard"
      };
      dashboardItem.Click += ShowDashboard;
      contextMenu.Items.Add(dashboardItem);

      var settingsItem = new ToolStripMenuItem() {
        Text = "Einstellungen"
      };
      settingsItem.Click += ShowSettings;
      contextMenu.Items.Add(settingsItem);

      var loginItem = new ToolStripMenuItem() {
        Text = "Logindaten ändern"
      };
      loginItem.Click += ShowLogin;
      contextMenu.Items.Add(loginItem);

      contextMenu.Items.Add(new ToolStripSeparator());

      var exitItem = new ToolStripMenuItem() {
        Text = "Schiessen"
      };
      exitItem.Click += Exit;
      contextMenu.Items.Add(exitItem);

      trayIcon = new NotifyIcon() {
        Icon = UtilLogic.GetAppIcon(),
        Text = "NesaBot",
        ContextMenuStrip = contextMenu,
        Visible = true
      };

      trayIcon.Click += ShowDashboard;

      PopupLogic.TrayIcon = trayIcon;

      UtilLogic.DoDefaultStuff();
    }

    private void ShowDashboard(object sender, EventArgs e) {
      MouseEventArgs mouseArgs = e as MouseEventArgs;

      if (mouseArgs != null && mouseArgs.Button != MouseButtons.Left) {
        return;
      }

      if (Application.OpenForms.OfType<DashboardForm>().Count() == 0) {
        dashboardForm = new DashboardForm();
        Task.Run(() => dashboardForm.ShowDialog());
      }
    }

    private void ShowSettings(object sender, EventArgs e) {
      if (Application.OpenForms.OfType<SettingsForm>().Count() == 0) {
        Task.Run(() => { 
          settingsForm.ShowDialog();
          UtilLogic.DoDefaultStuff();
        });
      }
    }

    private void ShowLogin(object sender, EventArgs e) {
      if (Application.OpenForms.OfType<LoginForm>().Count() == 0) {
        Task.Run(() => {
          loginForm.ShowDialog();
          UtilLogic.DoDefaultStuff();
        });
      }
    }

    private async void Exit(object sender, EventArgs e) {
      await DiscordLogic.Stop();

      trayIcon.Visible = false;

      Environment.Exit(0);
    }
  }
}