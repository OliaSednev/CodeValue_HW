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
            Console.WriteLine("Builds projects sequentially:");
            Console.WriteLine("--------------------------------------");
            Stopwatch stopwatchw = Stopwatch.StartNew();
            Sequentially();
            stopwatchw.Stop();

            Console.WriteLine("\nBuilds projects Concurrently:");
            Console.WriteLine("--------------------------------------");
            stopwatchw.Restart();
            Concurrently();
            stopwatchw.Stop();

        }
        static void Builder(int numProject)
        {
            Console.WriteLine($"Please wait, Building project number: {numProject}");
            Thread.Sleep(1000);
        }
        private static void Sequentially()
        {
            Builder(1);
            Builder(2);
            Builder(3);
            Builder(4);
            Builder(5);
            Builder(6);
            Builder(7);
            Builder(8);
        }
        private static void Concurrently()
        {
            Task task1 = Task.Factory.StartNew(() => Builder(1));
            Task task2 = Task.Factory.StartNew(() => Builder(2));
            Task task3 = Task.Factory.StartNew(() => Builder(3));
            Task task4 = task1.ContinueWith(p => Builder(4));
            Task task5 = Task.Factory.ContinueWhenAll(new Task[] { task1, task2, task3 }, project => Builder(5));
            Task task6 = Task.Factory.ContinueWhenAll(new Task[] { task3, task4 }, project => Builder(6));
            Task task7 = Task.Factory.ContinueWhenAll(new Task[] { task5, task6 }, project => Builder(7));
            Task task8 = task5.ContinueWith(project => Builder(8));
            Task.WaitAll(task5, task6, task7, task8);
        }
    }
}
