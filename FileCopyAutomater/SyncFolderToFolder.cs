using System;
using System.IO;
using System.Linq;

namespace FileCopyAutomater
{
    public class SyncFolderToFolder : IFileAndDirectoryData
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }

        public SyncFolderToFolder(string sourcePath, string targetPath)
        {
            SourcePath = Path.GetFullPath(sourcePath);
            TargetPath = Path.GetFullPath(targetPath);
            Name = new DirectoryInfo(TargetPath).Name;
            Size = GetDirectorySize(SourcePath);
        }

        private static long GetDirectorySize(string folderPath)
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);
            return di.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length);
        }

        public void Sync(bool overwrite)
        {
            if (overwrite)
            {
                Directory.Delete(TargetPath, true);
                Directory.CreateDirectory(TargetPath);
            }
            new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(SourcePath, TargetPath, overwrite);
        }
    }
}