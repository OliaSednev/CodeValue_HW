using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var getAllFiles = new FilesSearching();
                getAllFiles.GetAllFiles(args[0], args[1]);
                getAllFiles.DisplayFiles();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }




            //var getAllFiles = new FilesSearching();
            //getAllFiles.GetAllFiles(@"D:\CodeV-College\HW\tests", "Hello.txt");
            //getAllFiles.DisplayFiles();



        }



    }
}
