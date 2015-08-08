namespace DuplicateFilesRemover
{
    using System.Collections.Generic;
    using System.Linq;

    public class DuplicateFilesIdentifier
    {
        public virtual List<string> ReturnFileNamesOfDuplicates(List<FileInformations> filesInformations)
        {
            var groupsWithDuplicates = GroupFilesByMd5AndRetrieveThoseThatHaveDuplicates(filesInformations);
            return ExtractDuplicateFileNames(groupsWithDuplicates);
        }

        private List<IGrouping<string, FileInformations>> GroupFilesByMd5AndRetrieveThoseThatHaveDuplicates(List<FileInformations> filesInformations)
        {
            var groupedByMd5 = filesInformations.GroupBy(x => x.Md5);
            var groupsWithDuplicates = groupedByMd5.Where(x => x.Count() > 1).ToList();
            return groupsWithDuplicates;
        }

        private List<string> ExtractDuplicateFileNames(List<IGrouping<string, FileInformations>> groupsWithDuplicates)
        {
            var duplicateFiles = new List<string>();

            foreach (var groupWithDuplicates in groupsWithDuplicates)
                for (int i = 1; i < groupWithDuplicates.Count(); i++)
                    duplicateFiles.Add(groupWithDuplicates.ElementAt(i).Path);

            return duplicateFiles;
        }

        
    }
}