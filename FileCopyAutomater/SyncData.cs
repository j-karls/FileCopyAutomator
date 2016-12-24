using System;
using System.IO;

namespace FileCopyAutomater
{
    public class SyncData
    {
        public SyncData(string sourcePath, string targetPath, bool overwrites)
        {
            if (IsFile(sourcePath) && IsFile(targetPath))
            {
                SyncMember = new SyncFile(sourcePath, targetPath);
                MemberIsDirectory = false;
            }
            else if (IsDirectory(sourcePath) && IsFile(targetPath))
            {
                throw new ArgumentException("Cannot save a directory within a file");
            }
            else if (IsFile(sourcePath) && IsDirectory(targetPath))
            {
                string sourceFileName = Path.GetFileName(sourcePath);
                string fullTargetPath = Path.Combine(targetPath, sourceFileName);
                SyncMember = new SyncFile(sourcePath, fullTargetPath);
                MemberIsDirectory = false;
            }
            else if (IsDirectory(sourcePath) && IsDirectory(targetPath))
            {
                SyncMember = new SyncDirectory(sourcePath, targetPath);
                MemberIsDirectory = true;
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
        public bool MemberIsDirectory { get; private set; }
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