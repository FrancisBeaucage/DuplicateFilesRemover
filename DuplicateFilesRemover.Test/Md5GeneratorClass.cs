namespace DuplicateFilesRemover.Test
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Md5GeneratorClass
    {
        private const string TEST_DIRECTORY_PATH = "C:\\Users\\francis beaucage\\Documents\\Visual Studio 2015\\Projects\\DuplicateFilesRemover\\DuplicateFilesRemover.Test\\TestDirectory";
        private const string FIRST_FILE_PATH = TEST_DIRECTORY_PATH + "\\TestFile1.txt";
        private const string FIRST_FILE_MD5 = "5F-87-92-71-78-49-46-B0-93-D4-24-B6-37-B3-A6-F9";
        private const string SECOND_FILE_PATH = TEST_DIRECTORY_PATH + "\\TestFile2.txt";
        private const string SECOND_FILE_MD5 = "19-CE-C6-D6-70-D4-83-9F-FC-2F-C8-50-F0-9D-05-09";

        private readonly List<string> _directoryContent = new List<string> { FIRST_FILE_PATH, SECOND_FILE_PATH };

        private readonly List<FileInformations> _expectedFilesInformations = new List<FileInformations> { new FileInformations(FIRST_FILE_PATH, FIRST_FILE_MD5), new FileInformations(SECOND_FILE_PATH, SECOND_FILE_MD5) };

        [TestMethod]
        public void CanGenerateMd5s()
        {
            var generator = new Md5Generator();

            var filesInformations = generator.Generate(_directoryContent);

            Assert.AreEqual(2, filesInformations.Count);
            Assert.AreEqual(_expectedFilesInformations[0].Path, filesInformations[0].Path);
            Assert.AreEqual(_expectedFilesInformations[0].Md5, filesInformations[0].Md5);
            Assert.AreEqual(_expectedFilesInformations[1].Path, filesInformations[1].Path);
            Assert.AreEqual(_expectedFilesInformations[1].Md5, filesInformations[1].Md5);
        }
    }
}