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
            // To copy all the files in one directory to another directory.
            //// Get the files in the source folder. (To recursively iterate through
            //// all subfolders under the current directory, see
            //// "How to: Iterate Through a Directory Tree.")
            //// Note: Check for target path was performed previously
            ////       in this code example.
            //if (System.IO.Directory.Exists(sourcePath))
            //{
            //    string[] files = System.IO.Directory.GetFiles(sourcePath);

            //    // Copy the files and overwrite destination files if they already exist.
            //    foreach (string s in files)
            //    {
            //        // Use static Path methods to extract only the file name from the path.
            //        fileName = System.IO.Path.GetFileName(s);
            //        destFile = System.IO.Path.Combine(targetPath, fileName);
            //        System.IO.File.Copy(s, destFile, true);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Source path does not exist!");
            //}
        }
    }
}