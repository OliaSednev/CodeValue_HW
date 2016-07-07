using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    internal class FilesSearching
    {
        private readonly List<FileInfo> ListAfterSearching = new List<FileInfo>();

        public void GetAllFiles(string directory, string desiredFile)
        {
            var _file = "*" + desiredFile + "*"; //File should be in the search results, if any part of the name match

            foreach (var file in Directory.EnumerateFiles(directory, _file))
            {
                ListAfterSearching.Add(new FileInfo(file));
            }
            foreach (var subdirectory in Directory.EnumerateDirectories(directory))
                GetAllFiles(subdirectory, desiredFile); //next directory
        }

        public void DisplayFiles()
        {
            foreach (var file in ListAfterSearching)
            {
                Console.WriteLine($"File name: {file.Name}");
                //Console.WriteLine($"File Length: {file.Length}");
            }
        }
    }
}
