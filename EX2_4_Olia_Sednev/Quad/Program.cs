using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad
{
    class Quad
    {
        public void EntryToProgram(string[] args)
        {
            bool result = checkCoefficients(args); 
            if(result)
            {
                calculat(args);
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        public void calculat(string[] args)
        {
            double X, X1, X2, img;
           // for(int i = 0; i < args.Length; i++)
            double a_Coefficient = double.Parse(args[0]);
            double b_Coefficient = double.Parse(args[1]);
            double c_Coefficient = double.Parse(args[2]);
            double Delta = b_Coefficient * b_Coefficient - 4 * a_Coefficient * c_Coefficient;
            if(Delta > 0)
            {
                X1 = (-b_Coefficient + Math.Sqrt(Delta)) / 2 * a_Coefficient;
                X2 = (-b_Coefficient - Math.Sqrt(Delta)) / 2 * a_Coefficient;
                Console.WriteLine("Two Real Solutions: {0,8:f4} or  {1,8:f4}", X1, X2);
            }
            else if (Delta < 0)
            {
                Delta = -Delta;

                X = -b_Coefficient / (2 * a_Coefficient);
                img = Math.Sqrt(Delta) / (2*a_Coefficient);
                
                Console.WriteLine("Two Imaginary Solutions: {0,8:f4} + {1,8:f4} i or {2,8:f4} + {3,8:f4} i", X, img, X, img);
            }
            else
            {
                X = (-b_Coefficient + Math.Sqrt(Delta)) / (2 * a_Coefficient);
                Console.WriteLine("One Real Solution: {0,8:f4}", X);
            }
            
        }

        public bool checkCoefficients(string[] args)
        {
            int count = 0;
            for(int i=0; i<args.Length; i++)
            {
                count++;
            }
            if(count==3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var quad = new Quad();
            quad.EntryToProgram(args);
        }
    }
}
