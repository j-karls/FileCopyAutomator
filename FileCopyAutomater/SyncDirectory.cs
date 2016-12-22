using System;
using System.IO;
using System.Linq;

namespace FileCopyAutomater
{
    public class SyncDirectory : IFileAndDirectoryData
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }

        public SyncDirectory(string path)
        {
            SourcePath = Path.GetFullPath(path);
            Name = new DirectoryInfo(SourcePath).Name;
            Size = GetDirectorySize(SourcePath);

        }

        private static long GetDirectorySize(string folderPath)
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);
            return di.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length);
        }

        public void Sync(bool canOverwrite)
        {

        }
    }
}