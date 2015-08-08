namespace DuplicateFilesRemover
{
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var remover = new DuplicateFilesRemover(currentDirectory, new DirectoryContentRetriever(), new Md5Generator(), new DuplicateFilesIdentifier(), new FileDeleter());
            remover.Remove();
        }
    }
}
