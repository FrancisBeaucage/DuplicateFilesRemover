namespace DuplicateFilesRemover.Test
{
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FileDeleterTest
    {
        private const string FILE_TO_DELETE = "C:\\Users\\francis beaucage\\Documents\\Visual Studio 2015\\Projects\\DuplicateFilesRemover\\DuplicateFilesRemover.Test\\FileToDelete.txt";
        
        [TestMethod]
        public void CanDeleteFile()
        {
            var deleter = new FileDeleter();
            MakeSureFileIsNotPresentThanCreateIt();

            deleter.Delete(new List<string> { FILE_TO_DELETE });

            Assert.IsFalse(File.Exists(FILE_TO_DELETE));
        }

        private void MakeSureFileIsNotPresentThanCreateIt()
        {
            Assert.IsFalse(File.Exists(FILE_TO_DELETE));
            var file = File.Create(FILE_TO_DELETE);
            file.Close();
            Assert.IsTrue(File.Exists(FILE_TO_DELETE));
        }
    }
}