namespace DuplicateFilesRemover
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography;

    public class Md5Generator
    {
        public virtual List<FileInformations> Generate(List<string> fileNames)
        {
            var filesInformations = new List<FileInformations>();

            foreach (var fileName in fileNames) {
                using (var md5 = MD5.Create()) {
                    using (var stream = File.OpenRead(fileName)) {
                        var generatedMd5 = BitConverter.ToString(md5.ComputeHash(stream));
                        var fileInformations = new FileInformations(fileName, generatedMd5);
                        filesInformations.Add(fileInformations);
                    }
                }
            }

            return filesInformations;
        }
    }
}