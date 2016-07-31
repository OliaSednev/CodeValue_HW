﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex = new Mutex(false, "MySyncMutex");
            Console.WriteLine($"\nPlease wait, Process ID: {Process.GetCurrentProcess().Id} Write in to the file...");

            for (int i = 0; i < 10000; i++)
            {
                mutex.WaitOne();
                try
                {
                    using (StreamWriter writer = new StreamWriter(@"c:\temp\myTest.txt", true))
                    {
                        writer.WriteLine("Writing from process " + Process.GetCurrentProcess().Id);
                    }
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            Console.WriteLine("Done.");
        }
    }
}
