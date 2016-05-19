using System;
using System.Windows.Forms;

namespace Photo2FTP
{
    public partial class CameraForm : Form
    {
        public CameraForm()
        {
            InitializeComponent();
        }

        public CameraSettings CameraSettings { get; set; }

        public void LoadSettings()
        {
            if (CameraSettings == null)
            {
                return;
            }

            cameraLabelTextBox.Text = CameraSettings.Name;
            sourceFolderTextBox.Text = CameraSettings.SourceFolder;
            cameraIdentifierTextBox.Text = CameraSettings.Identifier;
            targetFolderTextBox.Text = CameraSettings.TargetFolder;
            newFileNameTextBox.Text = CameraSettings.TargetFile;
        }

        private void findSourceFolderButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                sourceFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                CameraSettings = new CameraSettings
                    {
                        Name = cameraLabelTextBox.Text,
                        SourceFolder = sourceFolderTextBox.Text,
                        Identifier = cameraIdentifierTextBox.Text,
                        TargetFile = newFileNameTextBox.Text,
                        TargetFolder = targetFolderTextBox.Text
                    };
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool IsValid
        {
            get
            {
                if (cameraLabelTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Není vyplněno označní kamery!", "Photo2FTP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cameraLabelTextBox.Focus();
                    return false;
                }

                if (cameraIdentifierTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Není vyplněn identifikátor kamery!", "Photo2FTP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cameraIdentifierTextBox.Focus();
                    return false;
                }

                if (sourceFolderTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Není vybrána cesta!", "Photo2FTP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    findSourceFolderButton.Focus();
                    return false;
                }

                return true;
            }
        }
    }
}
