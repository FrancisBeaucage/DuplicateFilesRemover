namespace DuplicateFilesRemover
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryContentRetriever
    {
        public virtual List<string> List(string currentDirectoryPath)
        {
            return Directory.EnumerateFiles(currentDirectoryPath).ToList();
        }
    }
}