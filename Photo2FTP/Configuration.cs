using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Xml;

namespace Photo2FTP
{
    public sealed class Configuration
    {
        private const string ConfigFile = "Photo2FTP.xml";

        private static Configuration _instance;

        private readonly List<CameraSettings> _cameraSettingList;

        private Configuration()
        {
            _cameraSettingList = new List<CameraSettings>();
            SetDefaults();
        }

        #region Properties

        public static Configuration Instance
        {
            get { return _instance ?? (_instance = new Configuration()); }
        }

        public int TimerSetting { get; set; }

        public int PartSize { get; set; }

        public string MeteoInfoFile { get; set; }

        public Font MeteoInfoFont { get; set; }

        public Color MeteoInfoFontColor { get; set; }

        public Color MeteoInfoOutlineColor { get; set; }

        public int MeteoInfoOutlineWidth { get; set; }

        public string Hostname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<CameraSettings> CameraSettingsList
        {
            get { return _cameraSettingList; }
        }

        #endregion

        #region Public Methods

        public void Save()
        {
            XmlDocument document = new XmlDocument();
            XmlDeclaration decl = document.CreateXmlDeclaration("1.0", "UTF-8", null);
            document.AppendChild(decl);

            XmlElement rootElem = document.CreateElement("Configuration");
            document.AppendChild(rootElem);

            XmlElement cameraList = document.CreateElement("CameraList");
            rootElem.AppendChild(cameraList);

            foreach (CameraSettings cameraSetting in CameraSettingsList)
            {
                XmlElement camera = AddElementWithAttribute(document, cameraList, "Camera", "Name", cameraSetting.Name);
                AddElementWithValue(document, camera, "SourceFolder", cameraSetting.SourceFolder);
                AddElementWithValue(document, camera, "TargetFolder", cameraSetting.TargetFolder);
                AddElementWithValue(document, camera, "TargetFile", cameraSetting.TargetFile);
            }

            AddElementWithAttribute(document, rootElem, "TimerSetting", "Value", TimerSetting.ToString());
            AddElementWithAttribute(document, rootElem, "PartSize", "Value", PartSize.ToString());
            AddElementWithValue(document, rootElem, "MeteoInfoFile", MeteoInfoFile);

            AddElementWithAttribute(document, rootElem, "MeteoInfoFont", "Name", MeteoInfoFont.FontFamily.Name, "Size", MeteoInfoFont.Size.ToString(Thread.CurrentThread.CurrentUICulture));
            AddElementWithAttribute(document, rootElem, "MeteoInfoFontColor", "Color", MeteoInfoFontColor.ToKnownColor().ToString());
            AddElementWithAttribute(document, rootElem, "MeteoInfoOutlineColor", "Color", MeteoInfoOutlineColor.ToKnownColor().ToString());
            AddElementWithAttribute(document, rootElem, "MeteoInfoOutlineWidth", "Value", MeteoInfoOutlineWidth.ToString());

            AddElementWithAttribute(document, rootElem, "Hostname", "Value", Hostname);
            AddElementWithAttribute(document, rootElem, "Username", "Value", Username);
            AddElementWithAttribute(document, rootElem, "Password", "Value", Password);

            document.Save(ConfigFile);
        }

        public void Load()
        {
            if (!File.Exists(ConfigFile))
            {
                return;
            }

            XmlDocument document = new XmlDocument();
            document.Load(ConfigFile);

            XmlElement rootElem = document["Configuration"];

            if (rootElem == null)
            {
                return;
            }

            TimerSetting = Convert.ToInt32(LoadAttributeValue(rootElem, "TimerSetting", "Value"));
            PartSize = Convert.ToInt32(LoadAttributeValue(rootElem, "PartSize", "Value"));
            MeteoInfoFile = LoadElementValue(rootElem, "MeteoInfoFile");

            string fontName = LoadAttributeValue(rootElem, "MeteoInfoFont", "Name");
            float size = Convert.ToSingle(LoadAttributeValue(rootElem, "MeteoInfoFont", "Size"));
            MeteoInfoFont = new Font(fontName, size);
            MeteoInfoFontColor = Color.FromName(LoadAttributeValue(rootElem, "MeteoInfoFontColor", "Color"));
            MeteoInfoOutlineColor = Color.FromName(LoadAttributeValue(rootElem, "MeteoInfoOutlineColor", "Color"));
            MeteoInfoOutlineWidth = Convert.ToInt32(LoadAttributeValue(rootElem, "MeteoInfoOutlineWidth", "Value"));

            Hostname = LoadAttributeValue(rootElem, "Hostname", "Value");
            Username = LoadAttributeValue(rootElem, "Username", "Value");
            Password = LoadAttributeValue(rootElem, "Password", "Value");

            XmlElement cameraListNode = rootElem["CameraList"];
            if (cameraListNode == null)
            {
                return;
            }
            XmlNodeList list = cameraListNode.GetElementsByTagName("Camera");
            for (int i = 0; i < list.Count; ++i)
            {
                XmlElement elem = list.Item(i) as XmlElement;
                if (elem == null)
                {
                    continue;
                }

                CameraSettings settings = new CameraSettings()
                {
                    Name = elem.GetAttribute("Name"),
                    SourceFolder = LoadElementValue(elem, "SourceFolder"),
                    TargetFolder = LoadElementValue(elem, "TargetFolder"),
                    TargetFile = LoadElementValue(elem, "TargetFile")
                };

                CameraSettingsList.Add(settings);
            }
        }

        #endregion

        #region Internals and Helpers

        private void SetDefaults()
        {
            TimerSetting = 1;
            PartSize = 100;
            MeteoInfoFile = String.Empty;

            MeteoInfoFont = new Font("Arial", 48);
            MeteoInfoFontColor = Color.WhiteSmoke;
            MeteoInfoOutlineColor = Color.Black;
            MeteoInfoOutlineWidth = 5;

            Hostname = String.Empty;
            Username = String.Empty;
            Password = String.Empty;
        }

        private void AddElementWithValue(XmlDocument document, XmlElement parentElement, string name, string value)
        {
            XmlElement elem = document.CreateElement(name);
            elem.AppendChild(document.CreateTextNode(value));
            parentElement.AppendChild(elem);
        }

        private XmlElement AddElementWithAttribute(XmlDocument document, XmlElement parentElement, string name, string attrName, string value, string attr2Name = null, string value2 = null)
        {
            XmlElement elem = document.CreateElement(name);
            parentElement.AppendChild(elem);

            XmlAttribute attr = document.CreateAttribute(attrName);
            attr.Value = value;
            elem.Attributes.Append(attr);

            if (attr2Name != null)
            {
                attr = document.CreateAttribute(attr2Name);
                attr.Value = value2 ?? String.Empty;
                elem.Attributes.Append(attr);
            }

            return elem;
        }

        private string LoadElementValue(XmlElement parentElem, string name)
        {
            XmlElement elem = parentElem[name];
            return elem != null ? elem.InnerText : String.Empty;
        }

        private string LoadAttributeValue(XmlElement parentElem, string elemName, string attrName)
        {
            XmlElement elem = parentElem[elemName];
            return elem != null ? elem.GetAttribute(attrName) : String.Empty;
        }

        #endregion
    }
}