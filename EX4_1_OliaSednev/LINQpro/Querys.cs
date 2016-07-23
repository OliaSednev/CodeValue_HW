using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LINQpro
{
    class Querys
    {
        public void InterfacesQuery()
        {
            var interfaceInfo = from method in typeof(string).Assembly.GetExportedTypes()
                where method.IsInterface && method.IsPublic
                orderby (method.Name)
                select method;
            foreach (var item in interfaceInfo)
            {
                Console.WriteLine($"Name: {item.Name}, count: {item.GetMethods().Count()}");
            }
        }

        public void ProcessesQuery()
        {
            var processInfo = from process in Process.GetProcesses()
                         where process.Threads.Count < 5
                         orderby (process.Id)
                         select process;
            foreach (var process in processInfo)
            {
                try
                {
                    Console.Write($"Process Name: {process.ProcessName}, ");
                    Console.Write($"ID: {process.Id}, ");
                    Console.Write("StartTime: ");
                    Console.WriteLine(process.StartTime);
                }
                catch (Win32Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SystemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void ProcessesQueryWithBasePriority()
        {
            var processInfo = from process in Process.GetProcesses()
                where process.Threads.Count < 5
                orderby (process.Id)
                group process by process.BasePriority
                into list
                orderby list.Key
                select list;
            foreach (var processByPriority in processInfo)
            {
                Console.WriteLine($"Base Priority {processByPriority.Key} :");
                Console.WriteLine("--------------------------------------");
                foreach (var process in processByPriority)
                {
                    try
                    {
                        Console.Write($"Process Name: {process.ProcessName}, ");
                        Console.Write($"ID: {process.Id}, ");
                        Console.Write("StartTime: ");
                        Console.WriteLine(process.StartTime);
                    }
                    catch (Win32Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);

                    }
                    catch (SystemException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }
        }

        public void Threads()
        {
            var totalNumberOfThreads = 0;
            var threadsInfo = from process in Process.GetProcesses()
                         select process.Threads.Count;
            foreach (var item in threadsInfo)
            {
                totalNumberOfThreads += item;
            }
            Console.WriteLine($"Total number of theards: {totalNumberOfThreads}");
        }
    }
}
