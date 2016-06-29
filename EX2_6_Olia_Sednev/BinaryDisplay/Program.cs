using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDisplay
{
    class BinaryDisplay
    {
        public void EntryToProgram()
        {
            Console.WriteLine("please enter number to convert to binary number:");
            string toBinary = Convert.ToString((int.Parse(Console.ReadLine())), 2);
            Console.WriteLine(toBinary);

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var binaryDisplay = new BinaryDisplay();
            binaryDisplay.EntryToProgram();
        }
    }
}
