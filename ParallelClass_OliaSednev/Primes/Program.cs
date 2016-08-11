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
            CalcPrimeNumbers primeNumbers = new CalcPrimeNumbers();
            var timePerCalcPrimeNumbers = Stopwatch.StartNew();
            var collectionOfPrimeNumbers = primeNumbers.CalcPrimes(0, 11, 2);
            timePerCalcPrimeNumbers.Stop();
            Console.WriteLine("The prime numbers:");
            foreach (var item in collectionOfPrimeNumbers)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine($"\nThe elapsed time: {timePerCalcPrimeNumbers.ElapsedMilliseconds}");

            timePerCalcPrimeNumbers.Restart();
            collectionOfPrimeNumbers = primeNumbers.CalcPrimes(0, 21, 3);
            timePerCalcPrimeNumbers.Stop();
            Console.WriteLine("The prime numbers:");
            foreach (var item in collectionOfPrimeNumbers)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine($"\nThe elapsed time: {timePerCalcPrimeNumbers.ElapsedMilliseconds}");

            timePerCalcPrimeNumbers.Restart();
            collectionOfPrimeNumbers = primeNumbers.CalcPrimes(0, 31, 4);
            timePerCalcPrimeNumbers.Stop();
            Console.WriteLine("The prime numbers:");
            foreach (var item in collectionOfPrimeNumbers)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine($"\nThe elapsed time: {timePerCalcPrimeNumbers.ElapsedMilliseconds}");
        }
    }
}
