using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Rational rational1 = new Rational(0, 2);
                Rational rational2 = new Rational(1, 2);
                Rational results = new Rational();

                Console.WriteLine("operator +");
                Console.WriteLine("*****************************");
                results = rational1 + rational2;
                Console.WriteLine(results.ToString());

                Console.WriteLine("\noperator -");
                Console.WriteLine("*****************************");
                results = rational1 - rational2;
                Console.WriteLine(results.ToString());

                Console.WriteLine("\noperator *");
                Console.WriteLine("*****************************");
                results = rational1 * rational2;
                Console.WriteLine(results.ToString());

                Console.WriteLine("\noperator /");
                Console.WriteLine("*****************************");
                results = rational1 / rational2;
                Console.WriteLine(results.ToString());


                Console.WriteLine("\nDouble explicit ");
                Console.WriteLine("*****************************");
                Console.WriteLine((double)new Rational(13, 3));

                Console.WriteLine("\nInt explicit ");
                Console.WriteLine("*****************************");
                Console.WriteLine((int)new Rational(13, 3));

                Console.WriteLine("\nFrom integer ");
                Console.WriteLine("*****************************");
                Console.WriteLine(new Rational(9, 3));
                Console.WriteLine();

            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
