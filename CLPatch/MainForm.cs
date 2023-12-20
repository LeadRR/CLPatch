// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Soloplan GmbH">
//   Copyright (c) Soloplan GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CLPatch
{
  using System.ServiceProcess;

  public partial class MainForm : Form
  {
    public MainForm()
    {
      this.InitializeComponent();
      this.FormClosing += Form1_FormClosing;
      PrerequisitesCheck.ShowMessageBoxRequested += this.ShowMessageBox;
      PrerequisitesCheck.UpdateStatusRequested += this.UpdateStatus;

      this.tabControl1.TabPages.Remove(this.tabPage1);
      this.tabControl1.TabPages.Remove(this.tabPage2);
      this.tabControl1.TabPages.Remove(this.tabPage3);
      this.tabControl1.TabPages.Remove(this.tabPage4);
      this.tabControl1.TabPages.Remove(this.tabPage5);
      this.tabControl1.TabPages.Remove(this.tabPage6);

      this.Shown += this.Form1_Shown;
    }

    private static void AdjustSize(Control? textBox)
    {
      if (textBox == null)
      {
        return;
      }

      var size = TextRenderer.MeasureText(textBox.Text, textBox.Font);
      textBox.Width = size.Width;
    }

    private bool NullOrEmptyCheck()
    {
      if (string.IsNullOrEmpty(this.openFileDialog1.FileName))
      {
        MessageBox.Show(
          $"Fehler: Patch Datei nicht ausgewählt oder ungültig.",
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return false;
      }

      if (string.IsNullOrEmpty(this.folderBrowserDialog1.SelectedPath))
      {
        MessageBox.Show(
          $"Fehler: Zielverzeichnis nicht ausgewählt oder ungültig.",
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return false;
      }

      if (!Directory.EnumerateFileSystemEntries(this.folderBrowserDialog1.SelectedPath).Any()) return true;
      {
        MessageBox.Show(
          $"Fehler: Bitte wählen Sie einen leeren Ordner als Zielverzeichnis.",
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return false;
      }
    }

    private void Browse1_Click(object sender, EventArgs e)
    {
      this.openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
      this.openFileDialog1.Filter = "Komprimierter Ordner (*.zip)|*.zip";
      this.openFileDialog1.ShowDialog();
    }

    private void Browse2_Click(object sender, EventArgs e)
    {
      this.folderBrowserDialog1.InitialDirectory = GlobalVariables.DestinationPath;
      var result = this.folderBrowserDialog1.ShowDialog();

      if (result != DialogResult.OK || string.IsNullOrWhiteSpace(this.folderBrowserDialog1.SelectedPath)) return;
      string selectedPath = this.folderBrowserDialog1.SelectedPath;
      this.textBox2.Text = selectedPath;
    }

    private static void Form1_FormClosing(object? sender, FormClosingEventArgs e)
    {
      string destinationPath = GlobalVariables.DestinationPath;

      if (!Directory.Exists(destinationPath)) return;
      try
      {
        string[] files = Directory.GetFiles(destinationPath, "*.*", SearchOption.TopDirectoryOnly);

        foreach (string file in files)
        {
          File.Delete(file);
        }

        string[] directories = Directory.GetDirectories(destinationPath, "*.*", SearchOption.TopDirectoryOnly);

        foreach (string dir in directories.Reverse())
        {
          Directory.Delete(dir, true);
        }

        Console.WriteLine("Files and Directories deleted.");
      }
      catch (IOException ioEx)
      {
        Console.WriteLine(ioEx.Message);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void Form1_Shown(object? sender, EventArgs e)
    {
      Dictionary<string, Tuple<string, string>> oracleInfo = RegistryUtility.GetOracleInfo();

      if (oracleInfo.Count > 1)
      {
        this.tabControl1.TabPages.Add(this.tabPage6);
        this.tabControl1.SelectTab(0);
        this.comboBox1.Visible = true;

        foreach (string key in oracleInfo.Keys)
        {
          this.comboBox1.Items.Add(key[4..]);
        }

        this.comboBox1.SelectedItem = this.comboBox1.Items[0]; // Select first item by default
      }
      else
      {
        this.tabControl1.TabPages.Add(this.tabPage1);
        this.tabControl1.SelectTab(0);
      }
    }

    private async Task<bool> CheckIfServicesStopped()
    {
      this.richTextBox2.Clear();
      List<ServiceController> services = ServiceUtility.GetServices(ServiceControllerStatus.Running);

      if (!services.Any())
      {
        await ServiceUtility.StopServices(this.richTextBox2);
        return true;
      }

      var dialogResult = MessageBox.Show(
        "Es wurden ein oder mehrere laufende Dienste gefunden. Möchten Sie versuchen, die Dienste automatisch zu beenden?",
        "Dienste gefunden",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

      switch (dialogResult)
      {
        case DialogResult.Yes:
        {
          await ServiceUtility.StopServices(this.richTextBox2);
          this.ShowButtons();
          break;
        }
        case DialogResult.No:
        case DialogResult.Cancel:
        {
          string serviceNames = string.Join(Environment.NewLine, services.Select(s => s.ServiceName));
          this.richTextBox2.AppendText("Laufende Dienste: " + Environment.NewLine + serviceNames);
          this.ShowButtons();
          break;
        }
        default:
          throw new ArgumentOutOfRangeException();
      }

      return false;
    }

    private async Task<bool> StartServices(RichTextBox richTextBox)
    {
      richTextBox.Clear();
      List<ServiceController> services = ServiceUtility.GetServices(ServiceControllerStatus.Stopped);

      var dialogResult = MessageBox.Show(
        "Möchten Sie die beendeten Dienste automatisch starten?",
        "Dienste Starten",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

      switch (dialogResult)
      {
        case DialogResult.Yes:
        {
          await ServiceUtility.StartServices(richTextBox);
          this.ShowButtons();
          break;
        }
        case DialogResult.No:
        case DialogResult.Cancel:
        {
          string serviceNames = string.Join(Environment.NewLine, services.Select(s => s.ServiceName));
          richTextBox.AppendText("Beendete Dienste: " + Environment.NewLine + serviceNames);
          this.ShowButtons();
          break;
        }
        default:
          throw new ArgumentOutOfRangeException();
      }

      return false;
    }

    private void HideButtons()
    {
      this.Weiter1.Hide();
      this.Weiter2.Hide();
      this.Weiter3.Hide();
      this.WeiterFinal.Hide();
      this.ServiceClose.Hide();
      this.ServiceStart.Hide();
      this.OpatchApply.Hide();
      LogFileButton.Hide();
    }

    private void ShowButtons()
    {
      this.Weiter1.Show();
      this.Weiter2.Show();
      this.Weiter3.Show();
      this.WeiterFinal.Show();
      this.ServiceClose.Show();
      this.ServiceStart.Show();
      this.OpatchApply.Show();
    }

    private void ShowMessageBox(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon, string currentVersion, string? requiredVersion)
    {
      if (this.richTextBox1.InvokeRequired)
      {
        this.richTextBox1.Invoke((Action?) Action);
      }
      else
      {
        Action();
      }

      return;

      void Action()
      {
        this.progressBar1.Hide();
        RemoveLogDetails();
        this.richTextBox1.AppendText($"\nFehler: Die aktuell installierte OPatch version ist die {currentVersion}, es wird jedoch für den Patch die version {requiredVersion} benötigt.");
        MessageBox.Show(message, title, buttons, icon);
      }

      void RemoveLogDetails()
      {
        const string LogStart = "Log file location";
        int startIndex = this.richTextBox1.Text.IndexOf(LogStart, StringComparison.Ordinal);

        if (startIndex != -1)
        {
          this.richTextBox1.Text = this.richTextBox1.Text.Remove(startIndex);
        }
      }
    }

    private void UpdateStatus(string status)
    {
      if (this.richTextBox1.InvokeRequired)
      {
        this.richTextBox1.Invoke(() => this.richTextBox1.AppendText(status + "\n"));
      }
      else
      {
        this.richTextBox1.AppendText(status + "\n");
      }
    }

    private async Task Step2()
    {
      this.tabControl1.TabPages.Add(this.tabPage2);
      this.tabControl1.SelectTab(1);
      this.tabControl1.TabPages.Remove(this.tabPage1);

      this.progressBar1.Style = ProgressBarStyle.Marquee;
      this.progressBar1.MarqueeAnimationSpeed = 25;

      Application.DoEvents();

      bool prerequisitesCheck = await this.PerformPrerequisitesCheck();
      this.progressBar1.Hide();

      if (prerequisitesCheck)
      {
        this.ShowButtons();
      }
    }

    private async Task<bool> PerformPrerequisitesCheck()
    {
      var prerequisitesCheckResult = false;
      await Task.Run(
        async () =>
        {
          prerequisitesCheckResult = await this.richTextBox1.Invoke(() => PrerequisitesCheck.PerformPrerequisitesCheck(this.richTextBox1));
        });

      this.progressBar1.Hide();
      return prerequisitesCheckResult;
    }

    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
      if (sender is TextBox textBox)
      {
        AdjustSize(textBox);
      }
    }

    private void TextBox2_TextChanged(object sender, EventArgs e)
    {
      if (sender is TextBox textBox)
      {
        AdjustSize(textBox);
      }
    }

    private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
      this.textBox1.Text = this.openFileDialog1.FileName;
      if (!string.IsNullOrEmpty(this.textBox1.Text))
      {
        this.Weiter1.Show();
      }
    }

    private async void Weiter1_Click(object sender, EventArgs e)
    {
      if (!this.NullOrEmptyCheck()) return;
      GlobalVariables.ZipFile = this.openFileDialog1.FileName;
      GlobalVariables.DestinationPath = this.folderBrowserDialog1.SelectedPath;

      Console.WriteLine("Patchverzeichnis: " + this.openFileDialog1.FileName);
      Console.WriteLine("Zielverzeichnis: " + this.folderBrowserDialog1.SelectedPath);
      this.HideButtons();
      await this.Step2();
    }

    private async void Weiter2_Click(object sender, EventArgs e)
    {
      this.tabControl1.TabPages.Add(this.tabPage3);
      this.tabControl1.SelectTab(1);
      this.tabControl1.TabPages.Remove(this.tabPage2);
      this.HideButtons();

      Application.DoEvents();
      if (await this.CheckIfServicesStopped())
        this.ShowButtons();
    }

    private async void Weiter3_Click(object sender, EventArgs e)
    {
      if (!await this.CheckIfServicesStopped())
      {
        this.Weiter3.Show();
        return;
      }

      this.tabControl1.TabPages.Add(this.tabPage4);
      this.tabControl1.SelectTab(1);
      this.tabControl1.TabPages.Remove(this.tabPage3);
      this.HideButtons();
      this.richTextBox3.AppendText("Bitte klicken sie auf 'Patch starten' um den Patch zu beginnen.");
      this.OpatchApply.Show();
    }

    private async void WeiterFinal_Click(object sender, EventArgs e)
    {
      this.tabControl1.TabPages.Add(this.tabPage5);
      this.tabControl1.SelectTab(1);
      this.tabControl1.TabPages.Remove(this.tabPage4);
      this.HideButtons();

      Application.DoEvents();
      if (await this.StartServices(this.richTextBox4))
        this.ShowButtons();
    }

    private void Weiter6_Click(object sender, EventArgs e)
    {
      string selectedOraHome = "KEY_" + this.comboBox1.SelectedItem;
      Dictionary<string, Tuple<string, string>> oracleInfo = RegistryUtility.GetOracleInfo();

      if (string.IsNullOrEmpty(selectedOraHome))
      {
        MessageBox.Show(
          $"Fehler: Keine Oracle Installation ausgewählt.",
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }

      GlobalVariables.OracleHomePath = oracleInfo[selectedOraHome].Item2;
      this.tabControl1.TabPages.Add(this.tabPage1);
      this.tabControl1.SelectTab(1);
      this.tabControl1.TabPages.Remove(this.tabPage6);
      this.HideButtons();
      this.Browse1.Show();

      if (!Directory.Exists(GlobalVariables.DestinationPath))
        Directory.CreateDirectory(GlobalVariables.DestinationPath);
    }

    private async void OpatchApply_Click(object sender, EventArgs e)
    {
      this.HideButtons();
      int lastIndex = GlobalVariables.ZipFile.LastIndexOf('\\');
      string formattedString = GlobalVariables.ZipFile[(lastIndex + 1)..];

      var dialogResult = MessageBox.Show(
        $"Möchten Sie mit dem Patch vorfahren?\n\n"
        + $"Installation: {GlobalVariables.OracleHomePath}\n\n"
        + $"Patch: {formattedString}\n\n",
        "Patch starten",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);
      if (dialogResult != DialogResult.Yes)
      {
        this.OpatchApply.Show();
        return;
      }

      this.richTextBox3.Clear();
      if (await OPatchApply.PatchApply(this.richTextBox3))
      {
        this.ShowButtons();
        this.OpatchApply.Hide();
      }
      else
      {
        MessageBox.Show(
          $"Fehler: OPatch fehlgeschlagen, siehe Log für weitere Informationen.",
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
      }
    }

    public static void LogFileButtonShow() { LogFileButton.Show(); }

    private void LogFileButton_Click(object sender, EventArgs e)
    {
      OPatchApply.OpenFileInDefaultApplication();
    }

    private async void ServiceClose_Click(object sender, EventArgs e)
    {
      this.richTextBox2.Clear();
      await ServiceUtility.StopServices(this.richTextBox2);
      this.ServiceClose.Hide();
    }

    private async void ServiceStart_Click(object sender, EventArgs e)
    {
      this.richTextBox4.Clear();
      await ServiceUtility.StartServices(this.richTextBox4);
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    // Autoscroll RichTextBox
    private void RichTextBox1_TextChanged(object sender, EventArgs e)
    {
      this.richTextBox1.SelectionStart = this.richTextBox1.Text.Length;
      this.richTextBox1.ScrollToCaret();
    }

    private void RichTextBox2_TextChanged(object sender, EventArgs e)
    {
      this.richTextBox2.SelectionStart = this.richTextBox2.Text.Length;
      this.richTextBox2.ScrollToCaret();
    }

    private void RichTextBox3_TextChanged(object sender, EventArgs e)
    {
      this.richTextBox3.SelectionStart = this.richTextBox3.Text.Length;
      this.richTextBox3.ScrollToCaret();
    }

    private void RichTextBox4_TextChanged(object sender, EventArgs e)
    {
      this.richTextBox4.SelectionStart = this.richTextBox4.Text.Length;
      this.richTextBox4.ScrollToCaret();
    }
  }
}
