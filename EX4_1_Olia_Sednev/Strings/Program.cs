using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str, temp;
            char delimiter =' ';

            Console.WriteLine("Please enter string:");
            temp= Console.ReadLine();
            str = temp.Trim();
          
            while (!(string.IsNullOrEmpty(str)))
            {
                String[] substrings = str.Split(delimiter);
                foreach (var substring in substrings)
                {
                    Console.WriteLine(substring);
                }

                Console.WriteLine("You have {0} words in your sentence.\n", substrings.Length);
                Console.WriteLine("Array revertions:");
                Array.Reverse(substrings);
                foreach (var substring in substrings)
                {
                    Console.WriteLine(substring);
                }
                Console.WriteLine("Array sorting:");
                Array.Sort<string>(substrings);
                foreach (var substring in substrings)
                {
                    Console.WriteLine(substring);
                }

                Console.WriteLine("Please enter string:");
                temp = Console.ReadLine();
                str = temp.Trim();

            }
        }
    }
}
