using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarStairs
{
    class DollarStairs
    {
        public void EntryToProgram()
        {
            Console.WriteLine("Please enter number:");
            int Number = int.Parse(Console.ReadLine());
            StairsCreation(Number);
        }

        private void StairsCreation(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                int prefixShift = i;
                while (prefixShift > 0)
                {
                    Console.Write("$");
                    prefixShift--;
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var stairs = new DollarStairs();
            stairs.EntryToProgram();
        }
    }
}
