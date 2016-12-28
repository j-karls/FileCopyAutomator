using System;
using System.IO;

namespace FileCopyAutomater
{
    public class SyncFileToFile : IFileAndDirectoryData
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }

        public SyncFileToFile(string sourcePath, string targetPath)
        {
            SourcePath = Path.GetFullPath(sourcePath);
            TargetPath = Path.GetFullPath(targetPath);
            Name = Path.GetFileName(TargetPath);
            Size = new FileInfo(SourcePath).Length;
        }

        public void Sync(bool overwrite)
        {
            if (overwrite)
            {
                File.Delete(TargetPath);
            }
            if (!File.Exists(TargetPath))
            {
                File.Create(TargetPath);
            }
            File.Copy(SourcePath, TargetPath, overwrite);
        }
    }
}