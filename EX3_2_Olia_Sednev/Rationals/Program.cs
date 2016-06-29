using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    struct Rational
    {
        private int _numerator;
        private int _denominator;
        public int Numerator {
            get { return _numerator; }
            set { _numerator = value; }
        }
        public int Denominator {
            get {return _denominator; }
            set { _denominator = value; }
        }
        public double Result { get {return Numerator/Denominator; } }
        public Rational(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }
        public Rational(int numerator)
        {
            _numerator = numerator;
            _denominator = 1;
        }
        public Rational Add(Rational obj1, Rational obj2)
        {
            Rational tempObj = new Rational();

            if(obj1._denominator == obj2._denominator)
            {
                tempObj._numerator = obj1._numerator + obj2._numerator;
                tempObj._denominator = obj1._denominator;
                Console.WriteLine("if");
                Console.WriteLine(tempObj.Numerator);
                Console.WriteLine(tempObj.Denominator);
            }
            else
            {
                tempObj._numerator = (obj1._numerator * obj2._denominator) + (obj2._numerator * obj1._denominator);
                tempObj._denominator = (obj1._denominator * obj2._denominator);
                Console.WriteLine("else");
                Console.WriteLine(tempObj.Numerator);
                Console.WriteLine(tempObj.Denominator);
            }
            return tempObj;

        }

        public Rational Mul(Rational obj1, Rational obj2)
        {
            Rational tempObj = new Rational();
            tempObj._numerator = (obj1.Numerator * obj2.Numerator);
            tempObj._denominator = (obj1.Denominator * obj2.Denominator);
            Console.WriteLine(tempObj.Numerator);
            Console.WriteLine(tempObj.Denominator);
            return tempObj;

        }
        public Rational Reduce(Rational obj1, Rational obj2)
        {
            Rational tempObj = new Rational();

            if (obj1._denominator == obj2._denominator)
            {
                tempObj._numerator = obj1._numerator - obj2._numerator;
                tempObj._denominator = obj1._denominator;
                Console.WriteLine("if");
                Console.WriteLine(tempObj._numerator);
                Console.WriteLine(tempObj._denominator);
            }
            else
            {
                tempObj._numerator = (obj1._numerator * obj2._denominator) - (obj2._numerator * obj1._denominator);
                tempObj._denominator = (obj1._denominator * obj2._denominator);
                Console.WriteLine("else");
                Console.WriteLine(tempObj.Numerator);
                Console.WriteLine(tempObj.Denominator);
            }
            return tempObj;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            Rational rational = (Rational)obj;
            return ((Numerator==rational.Numerator)&&(Denominator==rational.Denominator));
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
        
            Rational rational1 = new Rational(1, 2);
            Rational rational2 = new Rational(3, 4);
            Rational results = new Rational();

            Console.WriteLine("Add:");
            results.Add(rational1, rational2);

            Console.WriteLine(results.Denominator);
            Console.WriteLine(results.Numerator);
            //Console.WriteLine(results.Result);

            //Console.WriteLine("Mul:");
            //results.Mul(rational1, rational2);
            //Console.WriteLine(results.Result);
            //Console.WriteLine(results.Denominator);
            //Console.WriteLine(results.Numerator);

            //Console.WriteLine("Reduce:");
            //results.Reduce(rational1, rational2);
            //Console.WriteLine(results.Result);
            //Console.WriteLine(results.Denominator);
            //Console.WriteLine(results.Numerator);

            //Console.WriteLine("Override Equals:");
            //Rational rational3 = new Rational(1, 2);
            //Rational rational4 = new Rational(1, 2);
            //Console.WriteLine(rational1.Equals(rational2));



        }
    }
}
