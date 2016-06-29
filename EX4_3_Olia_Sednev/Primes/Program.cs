using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static int[] CalcPrimes(int lowRange, int highRange)
        {
            ArrayList list = new ArrayList();

            int flag = 0, count = 0;
            if(lowRange < 2)
            {
                lowRange = 2;
            }
            for (int i = lowRange; i <= highRange; i++)
            {
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        flag++;
                        break;
                    }
                }
                if (flag == 0)
                {
                    list.Add(i);
                    count++;
                }
                else
                {
                    flag = 0;
                }
            }
            int[] targetArray = new int[count];
            list.CopyTo(targetArray);
            return targetArray;

        }
        
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter the lowest and highest numbers in the range and I will show you the prime numbers.");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            Console.Write("Please enter the lowest number in the range:  ");
            int lowRange = int.Parse(Console.ReadLine());
            Console.Write("Please enter the highest number in the range:  ");
            int highRange = int.Parse(Console.ReadLine());

            int[] array = CalcPrimes(lowRange, highRange);
            Console.WriteLine("\nPrime numbers in current range are:");
            Console.WriteLine("***********************************");
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }



        }
    }
}
