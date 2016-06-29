using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What’s your name ?");
            string userName = Console.ReadLine();
            Console.WriteLine("Holle {0}", userName);

            Console.WriteLine("Please enter number between 1-10:");
            int userSelectionOfNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < userSelectionOfNumber; i++)
            {
                int prefixShift = i;
                while (prefixShift != 0)
                {
                    Console.Write(" ");
                    prefixShift--;
                }
                Console.WriteLine(userName);
            }

        }
    }
}
