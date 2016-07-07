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
            try
            {
                //if ((args.Length == 2) && Directory.Exists(args[0]))
                //{
                    var getAllFiles = new FilesSearching();
                    getAllFiles.GetAllFiles(args[0], args[1]);
                    getAllFiles.DisplayFiles();
                //}
                //else
                //{
                //    Console.WriteLine("One or more of the search parameters is missing!!!");
                //}
            }

            catch (DirectoryNotFoundException DirNotFound)
            {
                Console.WriteLine("{0}", DirNotFound.Message);
            }
            catch (UnauthorizedAccessException UnAuthDir)
            {
                Console.WriteLine("UnAuthDir: {0}", UnAuthDir.Message);
            }
            catch (PathTooLongException LongPath)
            {
                Console.WriteLine("{0}", LongPath.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



    }
}
