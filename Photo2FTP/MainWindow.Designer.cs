namespace Photo2FTP
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hostnameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.meteoInfoTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.sizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.findMeteoFileButton = new System.Windows.Forms.Button();
            this.findPhotoUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.fontColorLabel = new System.Windows.Forms.Label();
            this.outlineColorLabel = new System.Windows.Forms.Label();
            this.outlineWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.selectOutlineColorButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.fontInfoLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.selectFontButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.deleteCameraButton = new System.Windows.Forms.Button();
            this.editCameraButton = new System.Windows.Forms.Button();
            this.addCameraButton = new System.Windows.Forms.Button();
            this.camerasListBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.findPhotoUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outlineWidthUpDown)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Uživatelské jméno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Heslo:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(108, 42);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(120, 20);
            this.usernameTextBox.TabIndex = 3;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(108, 66);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(120, 20);
            this.passwordTextBox.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hostnameTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.passwordTextBox);
            this.groupBox1.Controls.Add(this.usernameTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 340);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 98);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Nastavení FTP připojení ";
            // 
            // hostnameTextBox
            // 
            this.hostnameTextBox.Location = new System.Drawing.Point(108, 17);
            this.hostnameTextBox.Name = "hostnameTextBox";
            this.hostnameTextBox.Size = new System.Drawing.Size(120, 20);
            this.hostnameTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hostname:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.meteoInfoTextBox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.sizeUpDown);
            this.groupBox2.Controls.Add(this.findMeteoFileButton);
            this.groupBox2.Controls.Add(this.findPhotoUpDown);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Parametry odesílání ";
            // 
            // meteoInfoTextBox
            // 
            this.meteoInfoTextBox.Location = new System.Drawing.Point(153, 13);
            this.meteoInfoTextBox.Name = "meteoInfoTextBox";
            this.meteoInfoTextBox.ReadOnly = true;
            this.meteoInfoTextBox.Size = new System.Drawing.Size(231, 20);
            this.meteoInfoTextBox.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Soubor s meteo-informacemi:";
            // 
            // sizeUpDown
            // 
            this.sizeUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sizeUpDown.Location = new System.Drawing.Point(153, 65);
            this.sizeUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.sizeUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sizeUpDown.Name = "sizeUpDown";
            this.sizeUpDown.ReadOnly = true;
            this.sizeUpDown.Size = new System.Drawing.Size(48, 20);
            this.sizeUpDown.TabIndex = 14;
            this.sizeUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // findMeteoFileButton
            // 
            this.findMeteoFileButton.Location = new System.Drawing.Point(389, 13);
            this.findMeteoFileButton.Name = "findMeteoFileButton";
            this.findMeteoFileButton.Size = new System.Drawing.Size(25, 20);
            this.findMeteoFileButton.TabIndex = 9;
            this.findMeteoFileButton.Text = "...";
            this.findMeteoFileButton.UseVisualStyleBackColor = true;
            this.findMeteoFileButton.Click += new System.EventHandler(this.findMeteoFileButton_Click);
            // 
            // findPhotoUpDown
            // 
            this.findPhotoUpDown.Location = new System.Drawing.Point(153, 41);
            this.findPhotoUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.findPhotoUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.findPhotoUpDown.Name = "findPhotoUpDown";
            this.findPhotoUpDown.ReadOnly = true;
            this.findPhotoUpDown.Size = new System.Drawing.Size(32, 20);
            this.findPhotoUpDown.TabIndex = 11;
            this.findPhotoUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(207, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "kB";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Odesílat po";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(191, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "minut";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hledat novou fotku každých";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(45, 26);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Spustit";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(45, 57);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Ukončit";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.startButton);
            this.groupBox3.Controls.Add(this.stopButton);
            this.groupBox3.Location = new System.Drawing.Point(276, 340);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 98);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Proces ";
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.HorizontalScrollbar = true;
            this.logListBox.Location = new System.Drawing.Point(12, 457);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(420, 160);
            this.logListBox.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 441);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Log:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "HTML soubor (*.html)|*.html|Všechny soubory (*.*)|*.*";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.fontColorLabel);
            this.groupBox4.Controls.Add(this.outlineColorLabel);
            this.groupBox4.Controls.Add(this.outlineWidthUpDown);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.selectOutlineColorButton);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.fontInfoLabel);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.selectFontButton);
            this.groupBox4.Location = new System.Drawing.Point(12, 234);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(420, 100);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " Nastavení fontu meteo-informací ";
            // 
            // fontColorLabel
            // 
            this.fontColorLabel.AutoSize = true;
            this.fontColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fontColorLabel.Location = new System.Drawing.Point(139, 22);
            this.fontColorLabel.Name = "fontColorLabel";
            this.fontColorLabel.Size = new System.Drawing.Size(24, 15);
            this.fontColorLabel.TabIndex = 8;
            this.fontColorLabel.Text = "     ";
            // 
            // outlineColorLabel
            // 
            this.outlineColorLabel.AutoSize = true;
            this.outlineColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outlineColorLabel.Location = new System.Drawing.Point(139, 49);
            this.outlineColorLabel.Name = "outlineColorLabel";
            this.outlineColorLabel.Size = new System.Drawing.Size(24, 15);
            this.outlineColorLabel.TabIndex = 5;
            this.outlineColorLabel.Text = "     ";
            // 
            // outlineWidthUpDown
            // 
            this.outlineWidthUpDown.Location = new System.Drawing.Point(108, 72);
            this.outlineWidthUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.outlineWidthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.outlineWidthUpDown.Name = "outlineWidthUpDown";
            this.outlineWidthUpDown.ReadOnly = true;
            this.outlineWidthUpDown.Size = new System.Drawing.Size(32, 20);
            this.outlineWidthUpDown.TabIndex = 7;
            this.outlineWidthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "Šířka obrysu:";
            // 
            // selectOutlineColorButton
            // 
            this.selectOutlineColorButton.Location = new System.Drawing.Point(108, 46);
            this.selectOutlineColorButton.Name = "selectOutlineColorButton";
            this.selectOutlineColorButton.Size = new System.Drawing.Size(25, 20);
            this.selectOutlineColorButton.TabIndex = 4;
            this.selectOutlineColorButton.Text = "..";
            this.selectOutlineColorButton.UseVisualStyleBackColor = true;
            this.selectOutlineColorButton.Click += new System.EventHandler(this.selectOutlineColorButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Barva obrysu:";
            // 
            // fontInfoLabel
            // 
            this.fontInfoLabel.AutoSize = true;
            this.fontInfoLabel.Location = new System.Drawing.Point(169, 22);
            this.fontInfoLabel.Name = "fontInfoLabel";
            this.fontInfoLabel.Size = new System.Drawing.Size(43, 13);
            this.fontInfoLabel.TabIndex = 2;
            this.fontInfoLabel.Text = "fontInfo";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Font:";
            // 
            // selectFontButton
            // 
            this.selectFontButton.Location = new System.Drawing.Point(108, 20);
            this.selectFontButton.Name = "selectFontButton";
            this.selectFontButton.Size = new System.Drawing.Size(25, 20);
            this.selectFontButton.TabIndex = 1;
            this.selectFontButton.Text = "...";
            this.selectFontButton.UseVisualStyleBackColor = true;
            this.selectFontButton.Click += new System.EventHandler(this.selectFontButton_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.WhiteSmoke;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.deleteCameraButton);
            this.groupBox5.Controls.Add(this.editCameraButton);
            this.groupBox5.Controls.Add(this.addCameraButton);
            this.groupBox5.Controls.Add(this.camerasListBox);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(420, 110);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " Nastavení kamer ";
            // 
            // deleteCameraButton
            // 
            this.deleteCameraButton.Location = new System.Drawing.Point(261, 77);
            this.deleteCameraButton.Name = "deleteCameraButton";
            this.deleteCameraButton.Size = new System.Drawing.Size(75, 23);
            this.deleteCameraButton.TabIndex = 3;
            this.deleteCameraButton.Text = "Smazat";
            this.deleteCameraButton.UseVisualStyleBackColor = true;
            this.deleteCameraButton.Click += new System.EventHandler(this.deleteCameraButton_Click);
            // 
            // editCameraButton
            // 
            this.editCameraButton.Location = new System.Drawing.Point(261, 48);
            this.editCameraButton.Name = "editCameraButton";
            this.editCameraButton.Size = new System.Drawing.Size(75, 23);
            this.editCameraButton.TabIndex = 2;
            this.editCameraButton.Text = "Upravit";
            this.editCameraButton.UseVisualStyleBackColor = true;
            this.editCameraButton.Click += new System.EventHandler(this.editCameraButton_Click);
            // 
            // addCameraButton
            // 
            this.addCameraButton.Location = new System.Drawing.Point(261, 19);
            this.addCameraButton.Name = "addCameraButton";
            this.addCameraButton.Size = new System.Drawing.Size(75, 23);
            this.addCameraButton.TabIndex = 1;
            this.addCameraButton.Text = "Přidat";
            this.addCameraButton.UseVisualStyleBackColor = true;
            this.addCameraButton.Click += new System.EventHandler(this.addCameraButton_Click);
            // 
            // camerasListBox
            // 
            this.camerasListBox.FormattingEnabled = true;
            this.camerasListBox.Location = new System.Drawing.Point(6, 19);
            this.camerasListBox.Name = "camerasListBox";
            this.camerasListBox.Size = new System.Drawing.Size(249, 82);
            this.camerasListBox.TabIndex = 0;
            this.camerasListBox.SelectedIndexChanged += new System.EventHandler(this.camerasListBox_SelectedIndexChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 622);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(460, 660);
            this.MinimumSize = new System.Drawing.Size(460, 660);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Photo2FTP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.findPhotoUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outlineWidthUpDown)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox usernameTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox hostnameTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown findPhotoUpDown;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.NumericUpDown sizeUpDown;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox meteoInfoTextBox;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button findMeteoFileButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.FontDialog fontDialog;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button selectFontButton;
		private System.Windows.Forms.Label outlineColorLabel;
		private System.Windows.Forms.NumericUpDown outlineWidthUpDown;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button selectOutlineColorButton;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label fontInfoLabel;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.Label fontColorLabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button deleteCameraButton;
        private System.Windows.Forms.Button editCameraButton;
        private System.Windows.Forms.Button addCameraButton;
        private System.Windows.Forms.ListBox camerasListBox;

	}
}

