using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Photo2FTP
{
    public class DataManager
    {
        #region ATTRIBUTES

        private static DataManager _instance;
        private static readonly object _syncRoot = new object();

        private readonly Dictionary<string, string> _recentFiles;
        private readonly Dictionary<string, bool> _sendingStatus;

        #endregion ATTRIBUTES

        private DataManager(ILog log)
        {
            Log = log;
            _recentFiles = new Dictionary<string, string>();
            _sendingStatus = new Dictionary<string, bool>();
        }

        public static DataManager CreateInstance(ILog log)
        {
            return _instance ?? (_instance = new DataManager(log));
        }

        #region Properties

        private ILog Log
        {
            get;
            set;
        }

        private string CurrentMeteoInfo
        {
            get
            {
                StreamReader reader = new StreamReader(Configuration.Instance.MeteoInfoFile, Encoding.Default);
                string result = reader.ReadToEnd();
                reader.Close();
                return result;
            }
        }

        #endregion

        public void ProcessRequestAsync(CameraSettings cameraSettings, CancellationToken token)
        {
            Task.Factory.StartNew(() =>
                {
                    try
                    {
                        token.ThrowIfCancellationRequested();

                        if (IsSending(cameraSettings.Name))
                        {
                            LogCameraMessage(cameraSettings.Name, "stále probíhá odesílání");
                            return;
                        }

                        LogCameraMessage(cameraSettings.Name, String.Format("prohledávám složku '{0}'.", cameraSettings.SourceFolder));
                        string filePath = FindRecentFile(cameraSettings.SourceFolder);
                        if (!CheckRecentFile(cameraSettings.Name, filePath))
                        {
                            LogCameraMessage(cameraSettings.Name, "žádná nová fotka");
                            return;
                        }

                        token.ThrowIfCancellationRequested();

                        string targetFile = !String.IsNullOrEmpty(cameraSettings.TargetFile) ? cameraSettings.TargetFile : Path.GetFileName(filePath);

                        string tempFile = Path.GetTempFileName();

                        LogCameraMessage(cameraSettings.Name, "vytvářím fotku k odeslání");
                        CreateModifiedFile(filePath, tempFile);
                        LogCameraMessage(cameraSettings.Name, "načítám data do bufferu");
                        byte[] buffer = ReadToBuffer(tempFile);

                        token.ThrowIfCancellationRequested();

                        LogCameraMessage(cameraSettings.Name, "odesílám fotku na server");
                        Send(cameraSettings.TargetFolder, targetFile, buffer);
                        LogCameraMessage(cameraSettings.Name, "fotka odeslána");
                        File.Delete(tempFile);
                    }
                    catch (WebException)
                    {
                        LogCameraMessage(cameraSettings.Name, "nepodařilo se odeslat data na FTP server");
                        LogCameraMessage(cameraSettings.Name, "chyba při odeslání dat na FTP server, zkontrolujte parametry připojení a existenci cílové složky na FTP serveru");
                    }
                    catch (UriFormatException e)
                    {
                        LogCameraMessage(cameraSettings.Name, "nepodařilo se odeslat data na FTP server");
                        LogCameraMessage(cameraSettings.Name, String.Format("Chyba v URI: {0}", e.Message));
                    }
                    catch (Exception e)
                    {
                        LogCameraMessage(cameraSettings.Name, "nepodařilo se odeslat data na FTP server");
                        LogCameraMessage(cameraSettings.Name, String.Format("neznámá chyba při odesílání dat: '{0}'", e.Message));
                    }
                    finally
                    {
                        ResetCamera(cameraSettings.Name);
                    }
                }, token);
        }

        public void ResetRecentFiles()
        {
            lock (_syncRoot)
            {
                _recentFiles.Clear();
            }
        }

        #region Internals and Helpers

        private void LogCameraMessage(string camera, string text)
        {
            Log.LogText(String.Format("{0}: {1}", camera, text));
        }

        private bool IsSending(string camera)
        {
            lock (_syncRoot)
            {
                bool isSending;
                if (!_sendingStatus.TryGetValue(camera, out isSending))
                {
                    _sendingStatus.Add(camera, false);
                }
                return isSending;
            }
        }

        private string GetRecentFile(string camera)
        {
            lock (_syncRoot)
            {
                string value;
                if (!_recentFiles.TryGetValue(camera, out value))
                {
                    value = String.Empty;
                    _recentFiles.Add(camera, value);
                }
                return value;
            }
        }

        private void SetRecentFile(string camera, string recentFilePath)
        {
            lock (_syncRoot)
            {
                _recentFiles[camera] = recentFilePath;
            }
        }

        private void ResetCamera(string camera)
        {
            lock (_syncRoot)
            {
                _sendingStatus.Remove(camera);
            }
        }

        private string FindRecentFile(string sourceFolder)
        {
            List<FileInfo> files = new List<FileInfo>();
            FindFilesRecursive(sourceFolder, files);
            return files.Count == 0 ? null : files.OrderByDescending(f => f.LastAccessTime).First().FullName;
        }

        private void FindFilesRecursive(string folder, List<FileInfo> result)
        {
            result.AddRange(Directory.GetFiles(folder).Select(file => new FileInfo(file)).Where(fileInfo => fileInfo.Extension != ".db"));

            foreach (string dir in Directory.GetDirectories(folder))
            {
                FindFilesRecursive(dir, result);
            }
        }

        private bool CheckRecentFile(string camera, string recentFilePath)
        {
            string lastFilePath = GetRecentFile(camera);
            if (string.Compare(recentFilePath, lastFilePath, StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                return false;
            }
            SetRecentFile(camera, recentFilePath);
            return true;
        }

        private void CreateModifiedFile(string filePath, string outputFile)
        {
            FileStream fileStream = File.OpenWrite(outputFile);
            Image image = Image.FromFile(filePath);

            // modify image
            if (Configuration.Instance.MeteoInfoFile != String.Empty)
            {
                string meteoInfo = CurrentMeteoInfo;
                Font font = Configuration.Instance.MeteoInfoFont;
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Far;
                Graphics g = Graphics.FromImage(image);

                GraphicsPath gp = new GraphicsPath();
                gp.AddString(meteoInfo, font.FontFamily, (int)font.Style, font.Size, new RectangleF(0, 0, image.Width, image.Height), strFormat);

                Pen pen = new Pen(Configuration.Instance.MeteoInfoOutlineColor);
                pen.Width = Configuration.Instance.MeteoInfoOutlineWidth;

                g.DrawPath(pen, gp);
                SolidBrush brush = new SolidBrush(Configuration.Instance.MeteoInfoFontColor);
                g.FillPath(brush, gp);
            }

            // save image to temporary file
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)100);
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = qualityParam;

            ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(item => item.MimeType == "image/jpeg");

            try
            {
                image.Save(fileStream, codec, parameters);
            }
            finally
            {
                fileStream.Close();
            }
        }

        private byte[] ReadToBuffer(string fileName)
        {
            FileStream fileStream = File.OpenRead(fileName);
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            fileStream.Close();
            return buffer;
        }

        private FtpWebRequest CreateNewRequest(string targetFolder, string targetFile)
        {
            string requestString = String.Format("ftp://{0}/{1}{2}{3}", Configuration.Instance.Hostname, targetFolder, (targetFolder.Length == 0) ? "" : "/", targetFile);
            FtpWebRequest request = (FtpWebRequest.Create(requestString) as FtpWebRequest);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(Configuration.Instance.Username, Configuration.Instance.Password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            return request;
        }

        private void Send(string targetFolder, string targetFile, byte[] buffer)
        {
            FtpWebRequest request = CreateNewRequest(targetFolder, targetFile);
            Stream requestStream = request.GetRequestStream();

            int kB = Convert.ToInt32(Math.Ceiling(buffer.Length / (double)1024));
            int steps = Convert.ToInt32(Math.Ceiling(kB / (double)Configuration.Instance.PartSize));

            int size = Configuration.Instance.PartSize * 1024;

            for (int i = 0; i < steps; ++i)
            {
                int endSize = (i == steps - 1) ? (buffer.Length - i * size) : size;
                requestStream.Write(buffer, i * size, endSize);
                Application.DoEvents();
            }

            requestStream.Close();
        }

        #endregion
    }
}
