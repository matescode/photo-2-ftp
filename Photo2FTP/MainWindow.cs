using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo2FTP
{
    public partial class MainWindow : Form, ILog
    {
        private const int LogClearCount = 100;

        private DataManager _dataManager;
        private CancellationTokenSource _tokenSource;

        public MainWindow()
        {
            InitializeComponent();
            LoadConfiguration();
            EnableControls(true);
        }

        #region Properties

        private bool IsValid
        {
            get
            {
                if (hostnameTextBox.Text.Length == 0)
                {
                    MessageBox.Show(@"Není vyplněno hostname!", @"Photo2FTP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hostnameTextBox.Focus();
                    return false;
                }

                if (usernameTextBox.Text.Length == 0)
                {
                    MessageBox.Show(@"Není vyplněno uživatelské jméno!", @"Photo2FTP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    usernameTextBox.Focus();
                    return false;
                }

                if (passwordTextBox.Text.Length == 0)
                {
                    MessageBox.Show(@"Není vyplněno heslo!", @"Photo2FTP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    passwordTextBox.Focus();
                    return false;
                }

                return true;
            }
        }

        #endregion

        #region ILog Members

        public void LogText(string text)
        {
            Action logAction = () => logListBox.Items.Insert(0, text);
            if (InvokeRequired)
            {
                Invoke(logAction);
            }
            else
            {
                logAction();
            }
        }

        #endregion

        #region Event Handlers

        private void MainWindow_Load(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            _dataManager = DataManager.CreateInstance(this);
            // DirectoryManager.Instance.Log = (this);
            // IsSending = false;

            foreach (CameraSettings settings in Configuration.Instance.CameraSettingsList)
            {
                camerasListBox.Items.Add(settings);
            }
        }

        private void addCameraButton_Click(object sender, EventArgs e)
        {
            CameraForm cameraForm = new CameraForm();
            if (cameraForm.ShowDialog() == DialogResult.OK)
            {
                CameraSettings settings = cameraForm.CameraSettings;
                Configuration.Instance.CameraSettingsList.Add(settings);
                camerasListBox.Items.Add(settings);
            }
        }

        private void editCameraButton_Click(object sender, EventArgs e)
        {
            if (camerasListBox.SelectedItem == null)
            {
                return;
            }

            CameraForm cameraForm = new CameraForm();
            CameraSettings settings = camerasListBox.SelectedItem as CameraSettings;
            if (settings == null)
            {
                return;
            }

            cameraForm.CameraSettings = settings;
            cameraForm.LoadSettings();
            if (cameraForm.ShowDialog() == DialogResult.OK)
            {
                settings.Name = cameraForm.CameraSettings.Name;
                settings.SourceFolder = cameraForm.CameraSettings.SourceFolder;
                settings.TargetFolder = cameraForm.CameraSettings.TargetFolder;
                settings.TargetFile = cameraForm.CameraSettings.TargetFile;
            }
        }

        private void deleteCameraButton_Click(object sender, EventArgs e)
        {
            if (camerasListBox.SelectedItem == null)
            {
                return;
            }

            CameraSettings settings = camerasListBox.SelectedItem as CameraSettings;
            if (settings != null)
            {
                camerasListBox.Items.Remove(settings);
                Configuration.Instance.CameraSettingsList.Remove(settings);
            }
        }

        private void findMeteoFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                meteoInfoTextBox.Text = openFileDialog.FileName;
            }
        }

        private void selectFontButton_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Configuration.Instance.MeteoInfoFont;
            fontDialog.Color = Configuration.Instance.MeteoInfoFontColor;
            fontDialog.ShowColor = true;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Configuration.Instance.MeteoInfoFont = fontDialog.Font;
                Configuration.Instance.MeteoInfoFontColor = fontDialog.Color;
                RefreshFontInfo();
            }
        }

        private void selectOutlineColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Configuration.Instance.MeteoInfoOutlineColor;
            colorDialog.SolidColorOnly = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Configuration.Instance.MeteoInfoOutlineColor = colorDialog.Color;
                RefreshOutlineColorInfo();
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                return;
            }

            ApplyConfiguration();
            EnableControls(false);
            StartProcess(Convert.ToInt32(findPhotoUpDown.Value) * 60);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void camerasListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editCameraButton.Enabled = camerasListBox.SelectedItem != null;
            deleteCameraButton.Enabled = camerasListBox.SelectedItem != null;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Stop();
                ApplyConfiguration();
                Configuration.Instance.Save();
            }
            catch (Exception ex)
            {
                string error = String.Format("Chyba při ukládání konfigurace!\n{0}", ex.Message);
                MessageBox.Show(error, @"Photo2FTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Internals and Helpers

        private void StartProcess(int delayInSeconds)
        {
            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            Task.Factory.StartNew(() =>
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }

                    LogText("Proces spuštěn.");

                    int loopCount = 0;

                    while (true)
                    {
                        if (token.IsCancellationRequested)
                        {
                            break;
                        }

                        if (loopCount % delayInSeconds == 0)
                        {
                            ProcessOperation();
                        }

                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        loopCount++;
                    }
                    LogText("Proces ukončen");
                }, _tokenSource.Token).ContinueWith(t => EnableControls(true));
        }

        private void ProcessOperation()
        {
            try
            {
                foreach (CameraSettings cameraSetting in Configuration.Instance.CameraSettingsList)
                {
                    _dataManager.ProcessRequestAsync(cameraSetting, _tokenSource.Token);
                }
                CheckLog();
            }
            catch (Exception e)
            {
                Stop();
                LogText("Nastala neočekávaná chyba aplikace!");
                MessageBox.Show(String.Format("Neznámá chyba: {0}", e.Message), @"Photo2FTP", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void CheckLog()
        {
            if (logListBox.Items.Count > LogClearCount)
            {
                logListBox.Items.Clear();
            }
        }

        private void Stop()
        {
            if (_tokenSource == null)
            {
                return;
            }
            
            _tokenSource.Cancel();
            _tokenSource = null;
            _dataManager.ResetRecentFiles();
        }

        private void EnableControls(bool state)
        {
            // start, stop buttons
            startButton.Enabled = state;
            stopButton.Enabled = !state;

            // sending settings
            addCameraButton.Enabled = state;
            editCameraButton.Enabled = state && camerasListBox.SelectedItem != null;
            deleteCameraButton.Enabled = state && camerasListBox.SelectedItem != null;
            findPhotoUpDown.Enabled = state;
            sizeUpDown.Enabled = state;
            findMeteoFileButton.Enabled = state;

            // font settings
            selectFontButton.Enabled = state;
            selectOutlineColorButton.Enabled = state;
            outlineWidthUpDown.Enabled = state;

            // ftp settings
            hostnameTextBox.Enabled = state;
            usernameTextBox.Enabled = state;
            passwordTextBox.Enabled = state;
        }

        private void LoadConfiguration()
        {
            Configuration.Instance.Load();

            findPhotoUpDown.Value = Configuration.Instance.TimerSetting;
            sizeUpDown.Value = Configuration.Instance.PartSize;
            meteoInfoTextBox.Text = Configuration.Instance.MeteoInfoFile;

            outlineWidthUpDown.Value = Configuration.Instance.MeteoInfoOutlineWidth;

            hostnameTextBox.Text = Configuration.Instance.Hostname;
            usernameTextBox.Text = Configuration.Instance.Username;
            passwordTextBox.Text = Configuration.Instance.Password;

            RefreshFontInfo();
            RefreshOutlineColorInfo();
        }

        private void ApplyConfiguration()
        {
            Configuration.Instance.TimerSetting = Convert.ToInt32(findPhotoUpDown.Value);
            Configuration.Instance.PartSize = Convert.ToInt32(sizeUpDown.Value);
            Configuration.Instance.MeteoInfoFile = meteoInfoTextBox.Text;

            Configuration.Instance.MeteoInfoOutlineWidth = Convert.ToInt32(outlineWidthUpDown.Value);

            Configuration.Instance.Hostname = hostnameTextBox.Text;
            Configuration.Instance.Username = usernameTextBox.Text;
            Configuration.Instance.Password = passwordTextBox.Text;
        }

        private void RefreshFontInfo()
        {
            fontInfoLabel.Text = string.Format("{0}, {1} px", Configuration.Instance.MeteoInfoFont.Name, Configuration.Instance.MeteoInfoFont.Size);
            fontColorLabel.BackColor = Configuration.Instance.MeteoInfoFontColor;
        }

        private void RefreshOutlineColorInfo()
        {
            outlineColorLabel.BackColor = Configuration.Instance.MeteoInfoOutlineColor;
        }

        #endregion
    }
}
