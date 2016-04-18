namespace Photo2FTP
{
    partial class CameraForm
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
            this.newFileNameTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.findSourceFolderButton = new System.Windows.Forms.Button();
            this.targetFolderTextBox = new System.Windows.Forms.TextBox();
            this.sourceFolderTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cameraLabelTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // newFileNameTextBox
            // 
            this.newFileNameTextBox.Location = new System.Drawing.Point(159, 83);
            this.newFileNameTextBox.Name = "newFileNameTextBox";
            this.newFileNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.newFileNameTextBox.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Nové jméno souboru:";
            // 
            // findSourceFolderButton
            // 
            this.findSourceFolderButton.Location = new System.Drawing.Point(365, 32);
            this.findSourceFolderButton.Name = "findSourceFolderButton";
            this.findSourceFolderButton.Size = new System.Drawing.Size(25, 20);
            this.findSourceFolderButton.TabIndex = 4;
            this.findSourceFolderButton.Text = "...";
            this.findSourceFolderButton.UseVisualStyleBackColor = true;
            this.findSourceFolderButton.Click += new System.EventHandler(this.findSourceFolderButton_Click);
            // 
            // targetFolderTextBox
            // 
            this.targetFolderTextBox.Location = new System.Drawing.Point(159, 57);
            this.targetFolderTextBox.Name = "targetFolderTextBox";
            this.targetFolderTextBox.Size = new System.Drawing.Size(200, 20);
            this.targetFolderTextBox.TabIndex = 6;
            // 
            // sourceFolderTextBox
            // 
            this.sourceFolderTextBox.Location = new System.Drawing.Point(159, 32);
            this.sourceFolderTextBox.Name = "sourceFolderTextBox";
            this.sourceFolderTextBox.ReadOnly = true;
            this.sourceFolderTextBox.Size = new System.Drawing.Size(200, 20);
            this.sourceFolderTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cílová složka na FTP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Zdrojová složka:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Označení:";
            // 
            // cameraLabelTextBox
            // 
            this.cameraLabelTextBox.Location = new System.Drawing.Point(159, 6);
            this.cameraLabelTextBox.Name = "cameraLabelTextBox";
            this.cameraLabelTextBox.Size = new System.Drawing.Size(200, 20);
            this.cameraLabelTextBox.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(121, 109);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(202, 109);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Storno";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CameraForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(399, 137);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cameraLabelTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newFileNameTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.findSourceFolderButton);
            this.Controls.Add(this.targetFolderTextBox);
            this.Controls.Add(this.sourceFolderTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(415, 175);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(415, 175);
            this.Name = "CameraForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nastavení kamery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newFileNameTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button findSourceFolderButton;
        private System.Windows.Forms.TextBox targetFolderTextBox;
        private System.Windows.Forms.TextBox sourceFolderTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cameraLabelTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}