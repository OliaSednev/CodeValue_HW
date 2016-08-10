using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcPrimesAndCancellation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please wait until prime numbers calculation finish...");
            var collectionOfPrimeNumbers = CalcPrimes(0, 30000000);
            Console.WriteLine($"Was calculated:  {collectionOfPrimeNumbers.Count()} numbers, before being cancelled");
        }

        private static IEnumerable<int> CalcPrimes(int first, int last)
        {
            var random = new Random();
            var list = new List<int>();

            Parallel.For(first, last, (i, loopState) => 
            {
                lock (random)
                {
                    if (random.Next(10000000) == 0)
                    {
                        loopState.Stop();
                        Console.WriteLine("Stop has been called");
                        return;
                    }
                }

                var isPrimeNumber = true;
                for (int j = 2; j <= (int)Math.Sqrt(i); j++)
                    if (i % j == 0)
                    {
                        isPrimeNumber = false;
                        break;
                    }
                if (isPrimeNumber && i > 1)
                {
                    lock (list)
                    {
                        list.Add(i);
                    }
                }
            });
            return list;
        }
    }
}
