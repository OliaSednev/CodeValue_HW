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
            CalcPrimeNumbers primeNumbers = new CalcPrimeNumbers();
            Console.WriteLine("Please wait until prime numbers calculation finish...");
            var collectionOfPrimeNumbers = primeNumbers.CalcPrimes(0, 30000000);

            Console.WriteLine($"Was calculated:  {collectionOfPrimeNumbers.Count()} numbers, before being cancelled");
        }
    }
}
