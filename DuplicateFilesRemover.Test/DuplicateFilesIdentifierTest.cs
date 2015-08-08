namespace DuplicateFilesRemover.Test
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DuplicateFilesIdentifierTest
    {
        private static readonly FileInformations BaseFile = new FileInformations("Path 1", "Base Md5");
        private static readonly FileInformations FileDifferentThanBase = new FileInformations("Path 2", "Different Md5");
        private static readonly FileInformations FirstFileIdenticalToBase = new FileInformations("Path 3", "Base Md5");
        private static readonly FileInformations SecondFileIdenticalToBase = new FileInformations("Path 4", "Base Md5");

        private DuplicateFilesIdentifier _identifier;

        [TestInitialize]
        public void InitializeIdentifier()
        {
            _identifier = new DuplicateFilesIdentifier();
        }

        [TestMethod]
        public void GivenNoFilesWhenVerifyThenThereAreNoDuplicateFiles()
        {
            var noFiles = new List<FileInformations>();
            var fileNamesOfDuplicateFiles = _identifier.ReturnFileNamesOfDuplicates(noFiles);
            Assert.AreEqual(0, fileNamesOfDuplicateFiles.Count);
        }

        [TestMethod]
        public void GivenOneFileWhenVerifyThenThereAreNoDuplicateFiles()
        {
            var oneFile = new List<FileInformations> { BaseFile };
            var fileNamesOfDuplicateFiles = _identifier.ReturnFileNamesOfDuplicates(oneFile);
            Assert.AreEqual(0, fileNamesOfDuplicateFiles.Count);
        }

        [TestMethod]
        public void GivenTwoDifferentFilesWhenVerifyThenThereAreNoDuplicateFiles()
        {
            var twoDifferentFiles = new List<FileInformations> { BaseFile, FileDifferentThanBase };
            var fileNamesOfDuplicateFiles = _identifier.ReturnFileNamesOfDuplicates(twoDifferentFiles);
            Assert.AreEqual(0, fileNamesOfDuplicateFiles.Count);
        }

        [TestMethod]
        public void GivenTwoIdenticalFilesWhenVerifyThenTheSecondFileIsADuplicate()
        {
            var twoIdenticalFiles = new List<FileInformations> { BaseFile, FirstFileIdenticalToBase };

            var fileNamesOfDuplicateFiles = _identifier.ReturnFileNamesOfDuplicates(twoIdenticalFiles);

            Assert.AreEqual(1, fileNamesOfDuplicateFiles.Count);
            Assert.AreEqual(FirstFileIdenticalToBase.Path, fileNamesOfDuplicateFiles[0]);
        }

        [TestMethod]
        public void GivenThreeIdenticalFilesWhenVerifyThenTheLastTwoFilesAreDuplicates()
        {
            var threeIdenticalFiles = new List<FileInformations> { BaseFile, FirstFileIdenticalToBase, SecondFileIdenticalToBase };

            var fileNamesOfDuplicateFiles = _identifier.ReturnFileNamesOfDuplicates(threeIdenticalFiles);

            Assert.AreEqual(2, fileNamesOfDuplicateFiles.Count);
            Assert.AreEqual(FirstFileIdenticalToBase.Path, fileNamesOfDuplicateFiles[0]);
            Assert.AreEqual(SecondFileIdenticalToBase.Path, fileNamesOfDuplicateFiles[1]);
        }

        [TestMethod]
        public void GivenAllFilesWhenVerifyThenTheDuplicatesAreIdentified()
        {
            var threeIdenticalFiles = new List<FileInformations> { BaseFile, FirstFileIdenticalToBase, FileDifferentThanBase, SecondFileIdenticalToBase };

            var fileNamesOfDuplicateFiles = _identifier.ReturnFileNamesOfDuplicates(threeIdenticalFiles);

            Assert.AreEqual(2, fileNamesOfDuplicateFiles.Count);
            Assert.AreEqual(FirstFileIdenticalToBase.Path, fileNamesOfDuplicateFiles[0]);
            Assert.AreEqual(SecondFileIdenticalToBase.Path, fileNamesOfDuplicateFiles[1]);
        }
    }
}