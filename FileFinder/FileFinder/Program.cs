using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var getAllFiles = new FilesSearching();
            getAllFiles.GetAllFiles(@"D:\CodeV-College\HW\tests", "Hello.txt");
            getAllFiles.DisplayFiles();

        }


    }
}

