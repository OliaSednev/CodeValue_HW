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
            Job job = new Job("pro", 1);
            Console.WriteLine("My processes was opened");
            Process.Start("notepad");
            Process.Start("word");
            job.AddProcessToJob(Process.GetProcessesByName("notepad")[0]);
            job.AddProcessToJob(Process.GetProcessesByName("word")[0]);

            Console.WriteLine("For kill the processes, press Enter . . .");
            Console.ReadLine();
            job.Kill();


            Console.WriteLine("To create new processes, press Enter . . .");
            Console.ReadLine();
            for (int i = 0; i < 20; i++)
            {
                new Job(10240);
            }
            
            for (int i = 0; i < 20; i++)
            {
                new Job(1024);
            }

            //size have to be positive number bigger than zero

            //for (int i = 0; i < 20; i++)
            //{
            //    new Job(0);
            //}
        }
    }
}
