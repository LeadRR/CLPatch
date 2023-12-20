// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OPatchApply.cs" company="Soloplan GmbH">
//   Copyright (c) Soloplan GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CLPatch
{
  using System.Diagnostics;
  using System.Text;

  internal abstract class OPatchApply
  {
    private static string logFilePath = "";
    public static async Task<bool> PatchApply(TextBoxBase richTextBox)
    {
      var tcs = new TaskCompletionSource<bool>();
      string? firstDirectory = Directory.GetDirectories(GlobalVariables.DestinationPath).FirstOrDefault();
      if (firstDirectory == null) return false;
      string? secondDirectory = Directory.GetDirectories(firstDirectory).FirstOrDefault();

      var procInfo = new ProcessStartInfo("cmd.exe")
      {
        WorkingDirectory = secondDirectory,
        RedirectStandardOutput = true,
        RedirectStandardInput = true,
        UseShellExecute = false,
        CreateNoWindow = true
      };

      string opatchPath = Path.Combine(GlobalVariables.OracleHomePath, "OPatch");

      List<string> paths = procInfo.Environment["PATH"]!.Split(';').ToList();
      paths.Insert(0, opatchPath);
      procInfo.Environment["PATH"] = string.Join(';', paths);

      var output = new StringBuilder();
      var process = Process.Start(procInfo);

      if (process == null) return false;
      process.EnableRaisingEvents = true;

      process.OutputDataReceived += (_, e) =>
      {
        if (richTextBox.InvokeRequired)
        {
          richTextBox.Invoke(() => richTextBox.AppendText(e.Data + "\n"));
        }
        else
        {
          richTextBox.AppendText(e.Data + "\n");
        }

        output.Append(e.Data);
      };

      process.BeginOutputReadLine();

      await using var sw = process.StandardInput;
      if (!sw.BaseStream.CanWrite) return false;

      await sw.WriteLineAsync(@"set PATH=%ORACLE_HOME%\perl\bin;%PATH%");
      await sw.WriteLineAsync("set PERL5LIB=");
      await sw.WriteLineAsync("opatch apply -silent");
      sw.Close();

      process.Exited += (_, _) =>
      {
        tcs.SetResult(true);
      };
      await tcs.Task;

      var timestamp = DateTime.Now.ToString("ddHHmmss");
      logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"CLPatchLogs\\OPatchApply_{timestamp}.log");

      string? logDirectoryPath = Path.GetDirectoryName(logFilePath);
      if (!Directory.Exists(logDirectoryPath)) Directory.CreateDirectory(logDirectoryPath ?? @"C:\Windows\Temp\CLPatchLogs");
      await File.AppendAllTextAsync(logFilePath, richTextBox.Text);

      MainForm.LogFileButtonShow();
      return true;
    }

    public static void OpenFileInDefaultApplication()
    {
      Process.Start(new ProcessStartInfo(logFilePath) { UseShellExecute = true });
    }
  }
}
