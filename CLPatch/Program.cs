// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Soloplan GmbH">
//   Copyright (c) Soloplan GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CLPatch
{
  internal static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.Run(new MainForm());
    }
  }
}
