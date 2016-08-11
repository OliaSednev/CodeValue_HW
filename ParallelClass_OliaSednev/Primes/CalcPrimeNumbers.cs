using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class CalcPrimeNumbers
    {
        public ICollection<int> CalcPrimes(int first, int last, int degreeOfParallelism)
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
