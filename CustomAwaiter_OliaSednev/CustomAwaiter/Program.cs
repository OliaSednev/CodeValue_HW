using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncAwaiter().Wait();
        }

        private static async Task AsyncAwaiter()
        {
            //  GetAwaiter(this TimeSpan timeSpan)
            Console.WriteLine($"Await for 4 seconds. The time now: {DateTime.Now}");
            await TimeSpan.FromMilliseconds(4000);
            Console.WriteLine($"Await for 3 seconds. The time now: {DateTime.Now}");
            await TimeSpan.FromMilliseconds(3000);

            //  GetAwaiter(this int milliseconds)
            Console.WriteLine($"Await for 2 seconds. The time now: {DateTime.Now} ");
            await 2000;
            Console.WriteLine($"Await for 1 seconds. The time now: {DateTime.Now} ");
            await 1000;

            //  GetAwaiter(this Process process)
            try
            {
                await Process.Start("word");
            }
            catch (System.ComponentModel.Win32Exception exception)
            {
                Console.WriteLine($"Could not start process: {exception.Message}");
            }
            Console.WriteLine("Continue . . . ");
            

        }
    }

    public static class Awaiters
    {
        public static TaskAwaiter GetAwaiter(this TimeSpan timeSpan)
        {
            return Task.Delay(timeSpan).GetAwaiter();
        }
        public static TaskAwaiter GetAwaiter(this int milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).GetAwaiter();
        }
        public static TaskAwaiter<int> GetAwaiter(this Process process)
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            process.EnableRaisingEvents = true;
            process.Exited += (s, e) => tcs.TrySetResult(process.ExitCode);
            if (process.HasExited) tcs.TrySetResult(process.ExitCode);

            return tcs.Task.GetAwaiter();
        }
    }
}
