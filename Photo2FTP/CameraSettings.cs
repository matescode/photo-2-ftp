using System;

namespace Photo2FTP
{
    public sealed class CameraSettings
    {
        public CameraSettings()
        {
            TargetFolder = string.Empty;
            TargetFile = string.Empty;
        }

        public string Name { get; set; }

        public string SourceFolder { get; set; }

        public string Identifier { get; set; }

        public string TargetFolder { get; set; }

        public string TargetFile { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}