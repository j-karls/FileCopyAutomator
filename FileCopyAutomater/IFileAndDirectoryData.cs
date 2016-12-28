namespace FileCopyAutomater
{
    public enum SyncType
    {
        FileToFile,
        FileToFolder,
        FolderToFolder
    }

    public interface IFileAndDirectoryData
    {
        string SourcePath { get; set; }
        string TargetPath { get; set; }
        string Name { get; set; }
        long Size { get; set; }

        void Sync(bool overwrite);
    }
}