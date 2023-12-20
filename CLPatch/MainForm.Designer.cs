namespace CLPatch
{
  partial class MainForm
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      label1 = new Label();
      Weiter1 = new Button();
      tabControl1 = new TabControl();
      tabPage1 = new TabPage();
      label2 = new Label();
      textBox2 = new TextBox();
      Browse2 = new Button();
      label3 = new Label();
      textBox1 = new TextBox();
      Browse1 = new Button();
      tabPage2 = new TabPage();
      progressBar1 = new ProgressBar();
      richTextBox1 = new RichTextBox();
      Weiter2 = new Button();
      tabPage3 = new TabPage();
      ServiceClose = new Button();
      richTextBox2 = new RichTextBox();
      Weiter3 = new Button();
      tabPage4 = new TabPage();
      WeiterFinal = new Button();
      OpatchApply = new Button();
      richTextBox3 = new RichTextBox();
      tabPage5 = new TabPage();
      ExitButton = new Button();
      ServiceStart = new Button();
      richTextBox4 = new RichTextBox();
      tabPage6 = new TabPage();
      label4 = new Label();
      Weiter6 = new Button();
      comboBox1 = new ComboBox();
      openFileDialog1 = new OpenFileDialog();
      folderBrowserDialog1 = new FolderBrowserDialog();
      LogFileButton = new Button();
      tabControl1.SuspendLayout();
      tabPage1.SuspendLayout();
      tabPage2.SuspendLayout();
      tabPage3.SuspendLayout();
      tabPage4.SuspendLayout();
      tabPage5.SuspendLayout();
      tabPage6.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
      label1.Location = new Point(325, 9);
      label1.Name = "label1";
      label1.Size = new Size(208, 20);
      label1.TabIndex = 1;
      label1.Text = "CarLo® Database Patch Tool";
      // 
      // Weiter1
      // 
      Weiter1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      Weiter1.BackColor = Color.FromArgb(192, 0, 107);
      Weiter1.Cursor = Cursors.Hand;
      Weiter1.FlatStyle = FlatStyle.Flat;
      Weiter1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      Weiter1.ForeColor = Color.Snow;
      Weiter1.Location = new Point(765, 451);
      Weiter1.Name = "Weiter1";
      Weiter1.Size = new Size(85, 25);
      Weiter1.TabIndex = 3;
      Weiter1.Text = "Weiter";
      Weiter1.UseVisualStyleBackColor = false;
      Weiter1.Visible = false;
      Weiter1.Click += this.Weiter1_Click;
      // 
      // tabControl1
      // 
      tabControl1.Controls.Add(tabPage1);
      tabControl1.Controls.Add(tabPage2);
      tabControl1.Controls.Add(tabPage3);
      tabControl1.Controls.Add(tabPage4);
      tabControl1.Controls.Add(tabPage5);
      tabControl1.Controls.Add(tabPage6);
      tabControl1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
      tabControl1.Location = new Point(-3, 9);
      tabControl1.Name = "tabControl1";
      tabControl1.SelectedIndex = 0;
      tabControl1.Size = new Size(864, 505);
      tabControl1.TabIndex = 8;
      tabControl1.TabStop = false;
      // 
      // tabPage1
      // 
      tabPage1.Controls.Add(label2);
      tabPage1.Controls.Add(textBox2);
      tabPage1.Controls.Add(Browse2);
      tabPage1.Controls.Add(label3);
      tabPage1.Controls.Add(textBox1);
      tabPage1.Controls.Add(Browse1);
      tabPage1.Controls.Add(Weiter1);
      tabPage1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      tabPage1.Location = new Point(4, 22);
      tabPage1.Name = "tabPage1";
      tabPage1.Padding = new Padding(3);
      tabPage1.Size = new Size(856, 479);
      tabPage1.TabIndex = 0;
      tabPage1.Text = "Schritt 1";
      tabPage1.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
      label2.Location = new Point(13, 108);
      label2.Name = "label2";
      label2.Size = new Size(255, 21);
      label2.TabIndex = 19;
      label2.Text = "Bitte wählen sie das Zielverzeichnis.";
      // 
      // textBox2
      // 
      textBox2.Cursor = Cursors.Hand;
      textBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      textBox2.Location = new Point(13, 132);
      textBox2.Name = "textBox2";
      textBox2.PlaceholderText = "C:\\Windows\\Temp\\CLPatch";
      textBox2.ReadOnly = true;
      textBox2.Size = new Size(181, 23);
      textBox2.TabIndex = 18;
      textBox2.TabStop = false;
      textBox2.Click += this.Browse2_Click;
      textBox2.TextChanged += this.TextBox2_TextChanged;
      textBox2.DoubleClick += this.Browse2_Click;
      // 
      // Browse2
      // 
      Browse2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      Browse2.Cursor = Cursors.Hand;
      Browse2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      Browse2.Location = new Point(13, 161);
      Browse2.Name = "Browse2";
      Browse2.Size = new Size(101, 25);
      Browse2.TabIndex = 2;
      Browse2.Text = "Durchsuchen...";
      Browse2.UseVisualStyleBackColor = false;
      Browse2.Click += this.Browse2_Click;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
      label3.Location = new Point(11, 9);
      label3.Name = "label3";
      label3.Size = new Size(255, 21);
      label3.TabIndex = 13;
      label3.Text = "Bitte wählen sie die .zip patch Datei.";
      // 
      // textBox1
      // 
      textBox1.Cursor = Cursors.Hand;
      textBox1.Location = new Point(11, 33);
      textBox1.Name = "textBox1";
      textBox1.ReadOnly = true;
      textBox1.Size = new Size(181, 23);
      textBox1.TabIndex = 11;
      textBox1.TabStop = false;
      textBox1.Click += this.Browse1_Click;
      textBox1.TextChanged += this.TextBox1_TextChanged;
      textBox1.DoubleClick += this.Browse1_Click;
      // 
      // Browse1
      // 
      Browse1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      Browse1.Cursor = Cursors.Hand;
      Browse1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      Browse1.Location = new Point(11, 61);
      Browse1.Name = "Browse1";
      Browse1.Size = new Size(101, 25);
      Browse1.TabIndex = 1;
      Browse1.Text = "Durchsuchen...";
      Browse1.UseVisualStyleBackColor = false;
      Browse1.Click += this.Browse1_Click;
      // 
      // tabPage2
      // 
      tabPage2.Controls.Add(progressBar1);
      tabPage2.Controls.Add(richTextBox1);
      tabPage2.Controls.Add(Weiter2);
      tabPage2.Location = new Point(4, 22);
      tabPage2.Name = "tabPage2";
      tabPage2.Padding = new Padding(3);
      tabPage2.Size = new Size(856, 479);
      tabPage2.TabIndex = 1;
      tabPage2.Text = "Schritt 2";
      tabPage2.UseVisualStyleBackColor = true;
      // 
      // progressBar1
      // 
      progressBar1.Location = new Point(268, 451);
      progressBar1.Name = "progressBar1";
      progressBar1.Size = new Size(320, 23);
      progressBar1.TabIndex = 23;
      // 
      // richTextBox1
      // 
      richTextBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
      richTextBox1.Location = new Point(6, 6);
      richTextBox1.Name = "richTextBox1";
      richTextBox1.ReadOnly = true;
      richTextBox1.Size = new Size(843, 437);
      richTextBox1.TabIndex = 22;
      richTextBox1.Text = "";
      richTextBox1.TextChanged += this.RichTextBox1_TextChanged;
      // 
      // Weiter2
      // 
      Weiter2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      Weiter2.BackColor = Color.FromArgb(192, 0, 107);
      Weiter2.Cursor = Cursors.Hand;
      Weiter2.FlatStyle = FlatStyle.Flat;
      Weiter2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      Weiter2.ForeColor = Color.Snow;
      Weiter2.Location = new Point(765, 451);
      Weiter2.Name = "Weiter2";
      Weiter2.Size = new Size(85, 25);
      Weiter2.TabIndex = 3;
      Weiter2.Text = "Weiter";
      Weiter2.UseVisualStyleBackColor = false;
      Weiter2.Click += this.Weiter2_Click;
      // 
      // tabPage3
      // 
      tabPage3.Controls.Add(ServiceClose);
      tabPage3.Controls.Add(richTextBox2);
      tabPage3.Controls.Add(Weiter3);
      tabPage3.Location = new Point(4, 22);
      tabPage3.Name = "tabPage3";
      tabPage3.Padding = new Padding(3);
      tabPage3.Size = new Size(856, 479);
      tabPage3.TabIndex = 2;
      tabPage3.Text = "Schritt 3";
      tabPage3.UseVisualStyleBackColor = true;
      // 
      // ServiceClose
      // 
      ServiceClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ServiceClose.AutoSize = true;
      ServiceClose.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      ServiceClose.BackColor = Color.FromArgb(192, 0, 107);
      ServiceClose.Cursor = Cursors.Hand;
      ServiceClose.FlatStyle = FlatStyle.Flat;
      ServiceClose.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      ServiceClose.ForeColor = Color.Snow;
      ServiceClose.Location = new Point(6, 451);
      ServiceClose.Name = "ServiceClose";
      ServiceClose.Size = new Size(180, 27);
      ServiceClose.TabIndex = 24;
      ServiceClose.Text = "Dienste automatisch schließen";
      ServiceClose.UseVisualStyleBackColor = false;
      ServiceClose.Click += this.ServiceClose_Click;
      // 
      // richTextBox2
      // 
      richTextBox2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
      richTextBox2.Location = new Point(6, 6);
      richTextBox2.Name = "richTextBox2";
      richTextBox2.ReadOnly = true;
      richTextBox2.Size = new Size(843, 437);
      richTextBox2.TabIndex = 23;
      richTextBox2.Text = "";
      richTextBox2.TextChanged += this.RichTextBox2_TextChanged;
      // 
      // Weiter3
      // 
      Weiter3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      Weiter3.BackColor = Color.FromArgb(192, 0, 107);
      Weiter3.Cursor = Cursors.Hand;
      Weiter3.FlatStyle = FlatStyle.Flat;
      Weiter3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      Weiter3.ForeColor = Color.Snow;
      Weiter3.Location = new Point(765, 451);
      Weiter3.Name = "Weiter3";
      Weiter3.Size = new Size(85, 25);
      Weiter3.TabIndex = 14;
      Weiter3.Text = "Weiter";
      Weiter3.UseVisualStyleBackColor = false;
      Weiter3.Click += this.Weiter3_Click;
      // 
      // tabPage4
      // 
      tabPage4.Controls.Add(LogFileButton);
      tabPage4.Controls.Add(WeiterFinal);
      tabPage4.Controls.Add(OpatchApply);
      tabPage4.Controls.Add(richTextBox3);
      tabPage4.Location = new Point(4, 22);
      tabPage4.Name = "tabPage4";
      tabPage4.Padding = new Padding(3);
      tabPage4.Size = new Size(856, 479);
      tabPage4.TabIndex = 3;
      tabPage4.Text = "Schritt 4";
      tabPage4.UseVisualStyleBackColor = true;
      // 
      // WeiterFinal
      // 
      WeiterFinal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      WeiterFinal.BackColor = Color.FromArgb(192, 0, 107);
      WeiterFinal.Cursor = Cursors.Hand;
      WeiterFinal.FlatStyle = FlatStyle.Flat;
      WeiterFinal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      WeiterFinal.ForeColor = Color.Snow;
      WeiterFinal.Location = new Point(765, 451);
      WeiterFinal.Name = "WeiterFinal";
      WeiterFinal.Size = new Size(85, 25);
      WeiterFinal.TabIndex = 26;
      WeiterFinal.Text = "Weiter";
      WeiterFinal.UseVisualStyleBackColor = false;
      WeiterFinal.Click += this.WeiterFinal_Click;
      // 
      // OpatchApply
      // 
      OpatchApply.AutoSize = true;
      OpatchApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      OpatchApply.BackColor = Color.FromArgb(192, 0, 107);
      OpatchApply.Cursor = Cursors.Hand;
      OpatchApply.FlatStyle = FlatStyle.Flat;
      OpatchApply.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      OpatchApply.ForeColor = Color.Snow;
      OpatchApply.Location = new Point(6, 451);
      OpatchApply.Name = "OpatchApply";
      OpatchApply.Size = new Size(88, 27);
      OpatchApply.TabIndex = 25;
      OpatchApply.Text = "Patch starten";
      OpatchApply.UseVisualStyleBackColor = false;
      OpatchApply.Click += this.OpatchApply_Click;
      // 
      // richTextBox3
      // 
      richTextBox3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
      richTextBox3.Location = new Point(6, 6);
      richTextBox3.Name = "richTextBox3";
      richTextBox3.ReadOnly = true;
      richTextBox3.Size = new Size(843, 437);
      richTextBox3.TabIndex = 24;
      richTextBox3.Text = "";
      richTextBox3.TextChanged += this.RichTextBox3_TextChanged;
      // 
      // tabPage5
      // 
      tabPage5.Controls.Add(ExitButton);
      tabPage5.Controls.Add(ServiceStart);
      tabPage5.Controls.Add(richTextBox4);
      tabPage5.Location = new Point(4, 22);
      tabPage5.Name = "tabPage5";
      tabPage5.Padding = new Padding(3);
      tabPage5.Size = new Size(856, 479);
      tabPage5.TabIndex = 4;
      tabPage5.Text = "Abschluss";
      tabPage5.UseVisualStyleBackColor = true;
      // 
      // ExitButton
      // 
      ExitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ExitButton.BackColor = Color.FromArgb(192, 0, 107);
      ExitButton.Cursor = Cursors.Hand;
      ExitButton.FlatStyle = FlatStyle.Flat;
      ExitButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      ExitButton.ForeColor = Color.Snow;
      ExitButton.Location = new Point(765, 451);
      ExitButton.Name = "ExitButton";
      ExitButton.Size = new Size(85, 25);
      ExitButton.TabIndex = 27;
      ExitButton.Text = "Beenden";
      ExitButton.UseVisualStyleBackColor = false;
      ExitButton.Click += this.ExitButton_Click;
      // 
      // ServiceStart
      // 
      ServiceStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ServiceStart.AutoSize = true;
      ServiceStart.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      ServiceStart.BackColor = Color.FromArgb(192, 0, 107);
      ServiceStart.Cursor = Cursors.Hand;
      ServiceStart.FlatStyle = FlatStyle.Flat;
      ServiceStart.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      ServiceStart.ForeColor = Color.Snow;
      ServiceStart.Location = new Point(6, 451);
      ServiceStart.Name = "ServiceStart";
      ServiceStart.Size = new Size(166, 27);
      ServiceStart.TabIndex = 26;
      ServiceStart.Text = "Dienste automatisch starten";
      ServiceStart.UseVisualStyleBackColor = false;
      ServiceStart.Click += this.ServiceStart_Click;
      // 
      // richTextBox4
      // 
      richTextBox4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
      richTextBox4.Location = new Point(6, 6);
      richTextBox4.Name = "richTextBox4";
      richTextBox4.ReadOnly = true;
      richTextBox4.Size = new Size(843, 437);
      richTextBox4.TabIndex = 25;
      richTextBox4.Text = "";
      richTextBox4.TextChanged += this.RichTextBox4_TextChanged;
      // 
      // tabPage6
      // 
      tabPage6.Controls.Add(label4);
      tabPage6.Controls.Add(Weiter6);
      tabPage6.Controls.Add(comboBox1);
      tabPage6.Location = new Point(4, 22);
      tabPage6.Name = "tabPage6";
      tabPage6.Padding = new Padding(3);
      tabPage6.Size = new Size(856, 479);
      tabPage6.TabIndex = 5;
      tabPage6.Text = "Auswahl";
      tabPage6.UseVisualStyleBackColor = true;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
      label4.Location = new Point(345, 158);
      label4.Name = "label4";
      label4.Size = new Size(167, 21);
      label4.TabIndex = 28;
      label4.Text = "Installation auswählen:";
      // 
      // Weiter6
      // 
      Weiter6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      Weiter6.BackColor = Color.FromArgb(192, 0, 107);
      Weiter6.Cursor = Cursors.Hand;
      Weiter6.FlatStyle = FlatStyle.Flat;
      Weiter6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      Weiter6.ForeColor = Color.Snow;
      Weiter6.Location = new Point(765, 451);
      Weiter6.Name = "Weiter6";
      Weiter6.Size = new Size(85, 25);
      Weiter6.TabIndex = 27;
      Weiter6.Text = "Weiter";
      Weiter6.UseVisualStyleBackColor = false;
      Weiter6.Click += this.Weiter6_Click;
      // 
      // comboBox1
      // 
      comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
      comboBox1.FormattingEnabled = true;
      comboBox1.Location = new Point(364, 185);
      comboBox1.Name = "comboBox1";
      comboBox1.Size = new Size(120, 25);
      comboBox1.TabIndex = 0;
      comboBox1.Visible = false;
      // 
      // openFileDialog1
      // 
      openFileDialog1.FileOk += this.OpenFileDialog1_FileOk;
      // 
      // folderBrowserDialog1
      // 
      folderBrowserDialog1.InitialDirectory = "C:\\Windows\\Temp\\CLPatch";
      folderBrowserDialog1.SelectedPath = "C:\\Windows\\Temp\\CLPatch";
      // 
      // LogFileButton
      // 
      LogFileButton.AutoSize = true;
      LogFileButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      LogFileButton.BackColor = Color.FromArgb(192, 0, 107);
      LogFileButton.Cursor = Cursors.Hand;
      LogFileButton.FlatStyle = FlatStyle.Flat;
      LogFileButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
      LogFileButton.ForeColor = Color.Snow;
      LogFileButton.Location = new Point(374, 451);
      LogFileButton.Name = "LogFileButton";
      LogFileButton.Size = new Size(109, 27);
      LogFileButton.TabIndex = 27;
      LogFileButton.Text = "Log-Datei öffnen";
      LogFileButton.UseVisualStyleBackColor = false;
      LogFileButton.Click += this.LogFileButton_Click;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new SizeF(6F, 16F);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.BackColor = Color.FromArgb(243, 242, 249);
      this.ClientSize = new Size(859, 514);
      this.Controls.Add(label1);
      this.Controls.Add(tabControl1);
      this.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point);
      this.Icon = (Icon)resources.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MainForm";
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "CLPatch";
      tabControl1.ResumeLayout(false);
      tabPage1.ResumeLayout(false);
      tabPage1.PerformLayout();
      tabPage2.ResumeLayout(false);
      tabPage3.ResumeLayout(false);
      tabPage3.PerformLayout();
      tabPage4.ResumeLayout(false);
      tabPage4.PerformLayout();
      tabPage5.ResumeLayout(false);
      tabPage5.PerformLayout();
      tabPage6.ResumeLayout(false);
      tabPage6.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    #endregion
    private Label label1;
    private Button Weiter1;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;
    private Button Weiter2;
    private OpenFileDialog openFileDialog1;
    private Button Browse1;
    private FolderBrowserDialog folderBrowserDialog1;
    private TextBox textBox1;
    private Label label3;
    private TabPage tabPage4;
    private Label label2;
    private TextBox textBox2;
    private Button Browse2;
    private RichTextBox richTextBox1;
    private ProgressBar progressBar1;
    private Button Weiter3;
    private RichTextBox richTextBox2;
    private RichTextBox richTextBox3;
    private Button OpatchApply;
    private Button ServiceClose;
    private Button WeiterFinal;
    private TabPage tabPage5;
    private RichTextBox richTextBox4;
    private Button ServiceStart;
    private Button ExitButton;
    private TabPage tabPage6;
    private Button Weiter6;
    private ComboBox comboBox1;
    private Label label4;
    private static Button LogFileButton;
  }
}
