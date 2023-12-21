// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrerequisitesCheck.cs" company="Soloplan GmbH">
//   Copyright (c) Soloplan GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CLPatch
{
  using System.Diagnostics;
  using System.IO.Compression;
  using System.Text;
  using System.Text.RegularExpressions;

  public static class PrerequisitesCheck
  {
    /// <summary>
    /// Performs a patch prerequisite check using OPatch.
    /// </summary>
    /// <param name="richTextBox">The TextBoxBase control used to display the output.</param>
    /// <returns>True if OPatch succeeded; otherwise, false.</returns>
    private static async Task<bool> OPatchCheck(TextBoxBase richTextBox)
    {
      var tcs = new TaskCompletionSource<bool>();
      var procInfo = new ProcessStartInfo("cmd.exe", "/c opatch prereq CheckConflictAgainstOHWithDetail -ph ./")
      {
        WorkingDirectory = Directory.GetDirectories(GlobalVariables.DestinationPath).First(),
        RedirectStandardOutput = true,
        UseShellExecute = false,
        CreateNoWindow = true
      };
      // Berichtsheft
      // Erstelle das Oracle Home Verzeichnis welches OPatch enthält.
      string opatchPath = Path.Combine(GlobalVariables.OracleHomePath, "OPatch");

      // Erzeuge aus der Umgebungsvariable "Path" eine durch Semikolon getrennte Liste.
      List<string> paths = procInfo.Environment["PATH"]!.Split(';').ToList();

      // Füge das zuvor erzeugte Oracle Home-Verzeichnis an erster Stelle der Liste ein.
      paths.Insert(0, opatchPath);

      // Setze die Liste wieder zusammen und weise sie der Path-Variable zu.
      procInfo.Environment["PATH"] = string.Join(';', paths);

      var process = Process.Start(procInfo);
      var output = new StringBuilder();

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

        output.AppendLine(e.Data);
      };

      process.BeginOutputReadLine();

      process.Exited += (_, _) =>
      {
        tcs.SetResult(true);
      };

      await tcs.Task;

      var outputStr = output.ToString();

      if (!OpatchVersionCheck(outputStr))
      {
        return false;
      }

      if (outputStr.Contains("OPatch succeeded."))
      {
        return true;
      }

      var logFilePath = "Log file location not found in the output.";
      const string Pattern = @"Log file location : (.*\.log)";

      var match = Regex.Match(outputStr, Pattern);
      if (match.Success)
      {
        logFilePath = match.Groups[1].Value;
      }

      MessageBox.Show(
        $"Error: OPatch did not succeed. Check the log for more details.\nLog file location: {logFilePath}",
        "Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error);

      return false;
    }

    public static event Action<string, string, MessageBoxButtons, MessageBoxIcon, string, string?>? ShowMessageBoxRequested;

    /// <summary>
    /// Checks if the current OPatch version is compatible with the required version.
    /// </summary>
    /// <param name="outputStr">The output string obtained from the system.</param>
    /// <returns>
    /// <c>true</c> if the current OPatch version is compatible with the required version;
    /// otherwise, <c>false</c>.
    /// </returns>
    private static bool OpatchVersionCheck(string outputStr)
    {
      string currentOpatchVersion = GetCurrentOpatchVersion(outputStr);
      string? requiredOpatchVersion = SearchHtml();

      if (requiredOpatchVersion == null) return false;

      string[] currentVersionParts = currentOpatchVersion.Split('.');
      string[] requiredVersionParts = requiredOpatchVersion.Split('.');

      // Determine the maximum length between the two versions
      int maxLength = Math.Max(currentVersionParts.Length, requiredVersionParts.Length);

      // Loop through each part of the version
      for (var i = 0; i < maxLength; i++)
      {
        // Get the current and required parts of the version, defaulting to 0 if the part does not exist
        int currentPart = (i < currentVersionParts.Length) ? int.Parse(currentVersionParts[i]) : 0;
        int requiredPart = (i < requiredVersionParts.Length) ? int.Parse(requiredVersionParts[i]) : 0;

        // If the current part is less than the required part, show an error message and return false
        if (currentPart < requiredPart)
        {
          ShowMessageBoxRequested?.Invoke(
            $"Fehler: Mindestanforderung OPatch Version {requiredOpatchVersion} nicht erfüllt",
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            currentOpatchVersion,
            requiredOpatchVersion);
          return false;
        }

        // If the current part is greater than the required part, break the loop
        if (currentPart > requiredPart)
        {
          break;
        }
      }

      // If the function has not returned false by this point, return true
      return true;
    }

    public static async Task<bool> PerformPrerequisitesCheck(RichTextBox richTextBox)
    {
      if (!await ArchiveUtility())
        return false;

      return await OPatchCheck(richTextBox);
    }

    private static void CopyFile(string sourceFile, string destinationDirectory)
    {
      Directory.CreateDirectory(destinationDirectory);

      string destinationFile = Path.Combine(destinationDirectory, Path.GetFileName(sourceFile));

      File.Copy(sourceFile, destinationFile);
    }

    public static event Action<string>? UpdateStatusRequested;

    /// <summary>
    /// Unzips the last created .zip
    /// </summary>
    /// <returns>True if the extraction was successful; otherwise, false.</returns>
    private static async Task<bool> ArchiveUtility()
    {
      var stopwatch = new Stopwatch();
      stopwatch.Start();

      await Task.Run(() => CopyFile(GlobalVariables.ZipFile, GlobalVariables.DestinationPath));

      string[] items = Directory.GetFileSystemEntries(GlobalVariables.DestinationPath, "p*"); // Get items starting with "p"

      if (items.Length == 0) return false;

      string latestItem = items.OrderByDescending(File.GetCreationTime).First();

      if (Path.GetExtension(latestItem) != ".zip") return false;

      string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(latestItem);
      string newDirectoryPath = Path.Combine(GlobalVariables.DestinationPath, fileNameWithoutExtension);

      Directory.CreateDirectory(newDirectoryPath);
      UpdateStatusRequested?.Invoke($"Extracting file {Path.GetFileName(latestItem)}..");

      await Task.Run(() => ZipFile.ExtractToDirectory(latestItem, newDirectoryPath));
      UpdateStatusRequested?.Invoke($"File successfully extracted to: {Path.GetDirectoryName(newDirectoryPath)}\n");

      stopwatch.Stop();
      Console.WriteLine($"Zip Decompression took: {stopwatch.Elapsed.TotalSeconds} seconds.");

      return true;
    }

    /// <summary>
    /// Gets the current Opatch version from a given output string.
    /// </summary>
    /// <param name="outputStr">The output string to extract the Opatch version from.</param>
    /// <returns>The current Opatch version.</returns>
    private static string GetCurrentOpatchVersion(string outputStr)
    {
      var match = Regex.Match(outputStr, @"OPatch version\s*:\s*(\d+(?:\.\d+)*)");
      if (!match.Success) Console.WriteLine("Could not find current Opatch version");

      string currentOpatchVersion = match.Groups[1].Value.Trim();

      return currentOpatchVersion;
    }

    /// <summary>
    /// Searches a HTML file to extract the OPatch version.
    /// </summary>
    /// <returns>
    /// The OPatch version extracted from the HTML content, or null if the version could not be retrieved.
    /// </returns>
    private static string? SearchHtml()
    {
      string filePath = Directory.EnumerateFiles(GlobalVariables.DestinationPath, "README.html", SearchOption.AllDirectories).FirstOrDefault() ?? "";
      string? opatchVersion = null;

      try
      {
        string htmlContent = File.ReadAllText(filePath);

        const string Pattern = @"OPatch utility version\s*(\d+(?:\.\d+)*)";

        var match = Regex.Match(htmlContent, Pattern);

        if (match.Success)
        {
          opatchVersion = match.Groups[1].Value;
        }
      }
      catch (Exception e)
      {
        Console.WriteLine("An error occurred while trying to parse the HTML: " + e.Message);
      }

      return opatchVersion;
    }
  }
}
