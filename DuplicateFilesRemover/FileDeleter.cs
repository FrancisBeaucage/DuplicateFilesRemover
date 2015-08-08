namespace DuplicateFilesRemover
{
    using System.Collections.Generic;
    using System.IO;

    public class FileDeleter
    {
        public virtual void Delete(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
                File.Delete(fileName);
        }
    }
}