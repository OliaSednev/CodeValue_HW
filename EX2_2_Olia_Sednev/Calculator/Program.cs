using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        public void EntryToCalculatorProgram()
        {
            Console.WriteLine("Please enter first number");
            double number1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Please enter second number");
            double number2 = double.Parse(Console.ReadLine());

            char operation;
            do
            {
                Console.WriteLine("Please select the operation you want to do (+,-,* or /).");
                operation = char.Parse(Console.ReadLine());

            } while (!(CheckOperator(operation)));


            double result = CalculatorFunc(number1, number2, operation);
            Console.WriteLine("Results:\n----------------\n{0} {1} {2} =  {3}\n", number1, operation, number2, result);
        }



        private bool CheckOperator(char operation)
        {
            if ((operation == '+') || (operation == '-') || (operation == '*') || (operation == '/'))
                return true;
            else
                return false;
        }

        public double CalculatorFunc(double number1, double number2, char operation)
        {
            double result;

            switch (operation)
            {
                case '+':
                    result = number1 + number2;
                    break;
                case '-':
                    result = number1 - number2;
                    break;
                case '*':
                    result = number1 * number2;
                    break;
                case '/':
                    result = number1 / number2;
                    break;
                default:
                    throw new Exception();
            }
            return result;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var Calc = new Calculator();
            Calc.EntryToCalculatorProgram();
        }

        
    }
}
