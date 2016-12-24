using System;
using System.IO;

namespace FileCopyAutomater
{
    public class SyncFile : IFileAndDirectoryData
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }

        public SyncFile(string sourcePath, string targetPath)
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

            //string fileName = "test.txt";
            //string sourcePath = @"C:\Users\Public\TestFolder";
            //string targetPath = @"C:\Users\Public\TestFolder\SubDir";

            //// Use Path class to manipulate file and directory paths.
            //string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            //string destFile = System.IO.Path.Combine(targetPath, fileName);

            //// To copy a folder's contents to a new location:
            //// Create a new target folder, if necessary.
            //if (!System.IO.Directory.Exists(targetPath))
            //{
            //    System.IO.Directory.CreateDirectory(targetPath);
            //}

            //// To copy a file to another location and 
            //// overwrite the destination file if it already exists.
            //System.IO.File.Copy(sourceFile, destFile, true);
        }
    }
}