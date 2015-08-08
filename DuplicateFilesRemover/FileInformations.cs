namespace DuplicateFilesRemover
{
    public class FileInformations
    {
        public string Path { get; private set; }
        public string Md5 { get; private set; }

        public FileInformations(string path, string md5)
        {
            Path = path;
            Md5 = md5;
        }
    }
}