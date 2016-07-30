using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimesCalculator
{
    class Calculator
    {

        public IEnumerable<int> PrimesCalculator(int first, int last, WaitHandle handle)
        {
            List<int> listOfPrimesNumbers = new List<int>();
            for (int i = first; i <= last; i++)
            {
                if (handle != null && handle.WaitOne(0))
                {
                    break;
                }
                if (i == 1) { i++; }
                if (IsPrime(i))
                {
                    listOfPrimesNumbers.Add(i);
                }
            }
            return listOfPrimesNumbers;
        }
        private bool IsPrime(int number)
        {
            for (int i = 2; i <= (int)Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}