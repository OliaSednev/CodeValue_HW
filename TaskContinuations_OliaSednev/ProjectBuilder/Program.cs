using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            BuilderProjects builder = new BuilderProjects();
            Console.WriteLine("Builds projects sequentially:");
            Console.WriteLine("--------------------------------------");
            Stopwatch stopwatchw = Stopwatch.StartNew();
            builder.Sequentially();
            stopwatchw.Stop();

            Console.WriteLine("\nBuilds projects Concurrently:");
            Console.WriteLine("--------------------------------------");
            stopwatchw.Restart();
            builder.Concurrently();
            stopwatchw.Stop();
        }
    }
}
