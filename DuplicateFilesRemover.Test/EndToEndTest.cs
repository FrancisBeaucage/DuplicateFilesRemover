namespace DuplicateFilesRemover.Test
{
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EndToEndTest
    {
        private const string TEST_DIRECTORY_PATH = "C:\\Users\\francis beaucage\\Documents\\Visual Studio 2015\\Projects\\DuplicateFilesRemover\\DuplicateFilesRemover.Test\\EndToEndTestDirectory";
        private const string TEST_FILE_1 = TEST_DIRECTORY_PATH + "\\TestFile1.txt";
        private const string TEST_FILE_2 = TEST_DIRECTORY_PATH + "\\TestFile2.txt";
        private const string TEST_FILE_DUPLICATE = TEST_DIRECTORY_PATH + "\\TestFileDuplicate.txt";

        [TestMethod]
        public void CanDeleteDuplicateFile()
        {
            NavigateToTestDirectory();
            CopyFile();
            ConfirmThatAllFilesArePresent();
            RunProgram();
            ConfirmThatDuplicateFileWasRemoved();
        }

        private void NavigateToTestDirectory()
        {
            Directory.SetCurrentDirectory(TEST_DIRECTORY_PATH);
        }

        private void CopyFile()
        {
            if (!File.Exists(TEST_FILE_DUPLICATE))
                File.Copy(TEST_FILE_1, TEST_FILE_DUPLICATE);
        }

        private void ConfirmThatAllFilesArePresent()
        {
            Assert.IsTrue(File.Exists(TEST_FILE_1));
            Assert.IsTrue(File.Exists(TEST_FILE_2));
            Assert.IsTrue(File.Exists(TEST_FILE_DUPLICATE));
        }

        private void RunProgram()
        {
            Program.Main(new string[0]);
        }

        private void ConfirmThatDuplicateFileWasRemoved()
        {
            Assert.IsTrue(File.Exists(TEST_FILE_1));
            Assert.IsTrue(File.Exists(TEST_FILE_2));
            Assert.IsFalse(File.Exists(TEST_FILE_DUPLICATE));
        }
    }
}