namespace FileCopyAutomater
{
    public interface IFileAndDirectoryData
    {
        string SourcePath { get; set; }
        string TargetPath { get; set; }
        string Name { get; set; }
        long Size { get; set; }

        void Sync(bool canOverwrite);
    }
}