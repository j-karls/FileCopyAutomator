using System;
using System.IO;

namespace FileCopyAutomater
{
    public class SyncData
    {
        public SyncData(string sourcePath, string targetPath, bool overwrites)
        {
            if (File.Exists(sourcePath) && File.Exists(targetPath))
            {
                SyncMember = new SyncFile(sourcePath);
                IsDirectory = false;
            }
            else if (Directory.Exists(sourcePath) && Directory.Exists(targetPath))
            {
                SyncMember = new SyncDirectory(sourcePath);
                IsDirectory = true;
            }
            else
            {
                throw new ArgumentException("Invalid path");
            }
        }

        public IFileAndDirectoryData SyncMember { get; private set; }
        public bool IsDirectory { get; private set; }
        public bool Overwrites { get; set; }

        public string OverwritesToString
        {
            get { return Overwrites?"Yes":"No"; }
        }

        public void Sync()
        {
            SyncMember.Sync(Overwrites);
        }

    }
}