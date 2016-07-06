﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    internal class FilesSearching
    {
        public List<string> ListAfterSearching = new List<string>();

        public void GetFilesFromSubdirectories(string directory, string desiredFile)
        {
            foreach (string subdirectory in Directory.GetDirectories(directory))
            {
                try
                {
                    foreach (string file in Directory.GetFiles(subdirectory, desiredFile))
                    {
                        var name = Path.GetFileNameWithoutExtension(desiredFile);
                        var extension = Path.GetExtension(desiredFile);
                        var fName = Path.GetFileNameWithoutExtension(file);
                        var fExtension = Path.GetExtension(file);
                        if ((fName != null && fExtension != null && fName.Equals("*name*") && fExtension.Equals(".*")) ||
                            (fName != null && fExtension != null && fName.Equals("*") && fExtension.Equals("extension")))
                        {
                            ListAfterSearching.Add(Path.GetFileName(file));
                        }
                        
                    }
                    GetFilesFromSubdirectories(subdirectory, desiredFile); //Recursion
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        public void GetFilesFromDirectory(string directory, string desiredFile)
        {
            foreach (string file in Directory.GetFiles(directory, desiredFile))
            {
                ListAfterSearching.Add(Path.GetFileName(file));
            }
        }

        public void GetAllFiles(string directoryName, string fileName)
        {
            //var info= new FileInfo(fileName);
            //var fName= Path.GetFileNameWithoutExtension(info.Name);
            //var fExtension = Path.GetExtension(info.Extension);
            //List<string> paths=new List<string>();

            //var newPath = "*" + fName + "*" + "." + "*";
            //paths.Add(newPath);
            //newPath = "*" + fExtension;
            //paths.Add(newPath);

            //foreach (var item in paths)
            //{
            //    GetFilesFromDirectory(directoryName, item);
            //    GetFilesFromSubdirectories(directoryName, item);
            //}


            //GetFilesFromDirectory(directoryName, fileName);
            GetFilesFromSubdirectories(directoryName, fileName);

        }

        public void DisplayFiles()
        {
            foreach (var file in ListAfterSearching)
            {
                Console.WriteLine(file);
            }
        }
    }
}
