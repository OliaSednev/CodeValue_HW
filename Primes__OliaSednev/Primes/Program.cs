using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            var timePerCalcPrimeNumbers = Stopwatch.StartNew();
            var collectionOfPrimeNumbers = CalcPrimes(0, 11, 2);
            timePerCalcPrimeNumbers.Stop();
            Console.WriteLine("The prime numbers:");
            foreach (var item in collectionOfPrimeNumbers)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine($"\nThe elapsed time: {timePerCalcPrimeNumbers.ElapsedMilliseconds}");

            timePerCalcPrimeNumbers.Restart();
            collectionOfPrimeNumbers = CalcPrimes(0, 21, 3);
            timePerCalcPrimeNumbers.Stop();
            Console.WriteLine("The prime numbers:");
            foreach (var item in collectionOfPrimeNumbers)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine($"\nThe elapsed time: {timePerCalcPrimeNumbers.ElapsedMilliseconds}");

            timePerCalcPrimeNumbers.Restart();
            collectionOfPrimeNumbers = CalcPrimes(0, 31, 4);
            timePerCalcPrimeNumbers.Stop();
            Console.WriteLine("The prime numbers:");
            foreach (var item in collectionOfPrimeNumbers)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine($"\nThe elapsed time: {timePerCalcPrimeNumbers.ElapsedMilliseconds}");
        }

        private static ICollection<int> CalcPrimes(int first, int last, int degreeOfParallelism)
        {
            var list = new List<int>();
            ParallelOptions parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = degreeOfParallelism
            };

            Parallel.For(first, last, parallelOptions, i => // lambda expression for parallel loop
            {
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