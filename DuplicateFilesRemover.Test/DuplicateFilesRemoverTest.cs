namespace DuplicateFilesRemover.Test
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class DuplicateFilesRemoverTest
    {
        private const string CURRENT_DIRECTORY_PATH = "Current directory path";
        private readonly List<string> _listOfFileNames = new List<string> { "" };
        private readonly List<FileInformations> _listOfFileInformations = new List<FileInformations> { new FileInformations(null, null) };
        private readonly List<string> _namesOfDuplicateFiles = new List<string> { "" };

        private Mock<DirectoryContentRetriever> _directoryContentRetriever;
        private Mock<Md5Generator> _md5Generator;
        private Mock<DuplicateFilesIdentifier> _duplicateFilesIdentifier;
        private DuplicateFilesRemover _remover;
        private Mock<FileDeleter> _fileDeleter;

        [TestInitialize]
        public void InitializeRemover()
        {
            _directoryContentRetriever = new Mock<DirectoryContentRetriever>();
            _md5Generator = new Mock<Md5Generator>();
            _duplicateFilesIdentifier = new Mock<DuplicateFilesIdentifier>();
            _fileDeleter = new Mock<FileDeleter>();
            _remover = new DuplicateFilesRemover(CURRENT_DIRECTORY_PATH, _directoryContentRetriever.Object, _md5Generator.Object, _duplicateFilesIdentifier.Object, _fileDeleter.Object);
        }

        [TestMethod]
        public void CollaboratesWithDirectoryContentRetriever()
        {
            _remover.Remove();
            _directoryContentRetriever.Verify(x => x.List(CURRENT_DIRECTORY_PATH));
        }

        [TestMethod]
        public void SendsListOfFileNamesToMd5Generator()
        {
            _directoryContentRetriever.Setup(x => x.List(CURRENT_DIRECTORY_PATH)).Returns(_listOfFileNames);
            _remover.Remove();
            _md5Generator.Verify(x => x.Generate(_listOfFileNames));
        }

        [TestMethod]
        public void SendsListOfFileInformationsToDuplicateFilesIndentifier()
        {
            _md5Generator.Setup(x => x.Generate(It.IsAny<List<string>>())).Returns(_listOfFileInformations);
            _remover.Remove();
            _duplicateFilesIdentifier.Verify(x => x.ReturnFileNamesOfDuplicates(_listOfFileInformations));
        }

        [TestMethod]
        public void SendsListOfDuplicateFilesToFileDeleter()
        {
            _duplicateFilesIdentifier.Setup(x => x.ReturnFileNamesOfDuplicates(It.IsAny<List<FileInformations>>())).Returns(_namesOfDuplicateFiles);
            _remover.Remove();
            _fileDeleter.Verify(x => x.Delete(_namesOfDuplicateFiles));
        }
    }
}