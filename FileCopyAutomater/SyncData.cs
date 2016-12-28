using System;
using System.IO;

namespace FileCopyAutomater
{
    public class SyncData
    {
        public SyncData(string sourcePath, string targetPath, bool overwrites, SyncType syncType)
        {
            Type = syncType;

            if (Type == SyncType.FileToFile && IsFile(sourcePath) && IsFile(targetPath))
            {
                SyncMember = new SyncFileToFile(sourcePath, targetPath);
            }
            else if (Type == SyncType.FileToFolder && IsFile(sourcePath) && IsDirectory(targetPath))
            {
                string sourceFileName = Path.GetFileName(sourcePath);
                string fullTargetPath = Path.Combine(targetPath, sourceFileName);
                SyncMember = new SyncFileToFile(sourcePath, fullTargetPath);
            }
            else if (Type == SyncType.FolderToFolder && IsDirectory(sourcePath) && IsDirectory(targetPath))
            {
                SyncMember = new SyncFolderToFolder(sourcePath, targetPath);
            }
            else
            {
                throw new ArgumentException("Invalid path");
            }
        }

        private bool IsDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        private bool IsFile(string filePath)
        {
            FileInfo fi = null;
            try
            {
                fi = new FileInfo(filePath);
            }
            catch (ArgumentException) { }
            catch (PathTooLongException) { }
            catch (NotSupportedException) { }
            if (ReferenceEquals(fi, null))
            {
                // File path not valid
                return false;
            }
            else
            {
                // File path valid
                return true;
            }
        }

        public IFileAndDirectoryData SyncMember { get; private set; }
        public bool Overwrites { get; set; }
        public SyncType Type { get; private set; }

        public string OverwritesToString
        {
            get { return Overwrites ? "Yes" : "No"; }
        }

        public void Sync()
        {
            SyncMember.Sync(Overwrites);
        }

    }
}