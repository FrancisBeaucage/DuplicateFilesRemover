namespace DuplicateFilesRemover
{
    public class DuplicateFilesRemover
    {
        private readonly string _currentDirectoryPath;
        private readonly DirectoryContentRetriever _directoryContentRetriever;
        private readonly Md5Generator _md5Generator;
        private readonly DuplicateFilesIdentifier _duplicateFilesIdentifier;
        private readonly FileDeleter _fileDeleter;

        public DuplicateFilesRemover(string currentDirectoryPath, DirectoryContentRetriever directoryContentRetriever, Md5Generator md5Generator, DuplicateFilesIdentifier duplicateFilesIdentifier, FileDeleter fileDeleter)
        {
            _currentDirectoryPath = currentDirectoryPath;
            _directoryContentRetriever = directoryContentRetriever;
            _md5Generator = md5Generator;
            _duplicateFilesIdentifier = duplicateFilesIdentifier;
            _fileDeleter = fileDeleter;
        }

        public void Remove()
        {
            var fileNames = _directoryContentRetriever.List(_currentDirectoryPath);
            var fileInformations = _md5Generator.Generate(fileNames);
            var fileNamesOfDuplicates = _duplicateFilesIdentifier.ReturnFileNamesOfDuplicates(fileInformations);
            _fileDeleter.Delete(fileNamesOfDuplicates);
        }
    }
}
