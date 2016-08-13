using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs
{
    class Program
    {
        static void Main(string[] args)
        {
            Job job = new Job();
            Process.Start("notepad");
            Process.Start("wordpad");
            job.AddProcessToJob(Process.GetProcessesByName("notepad")[0]);
            job.AddProcessToJob(Process.GetProcessesByName("wordpad")[0]);
            Console.ReadLine();
            job.Kill();


        }
    }
}
