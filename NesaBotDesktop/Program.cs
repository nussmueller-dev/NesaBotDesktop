using NesaBotDesktop.Forms;
using System.Diagnostics;

namespace NesaBotDesktop {
  internal static class Program {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      if (PriorProcess() != null) {
        return;
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      ApplicationConfiguration.Initialize();
      Application.Run(new DashboardForm());
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
}