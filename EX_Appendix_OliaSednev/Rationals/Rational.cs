using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    struct Rational
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
        public double ToDouble { get { return (double)Numerator / Denominator; } }
        public int ToInt { get { return (int)Numerator / Denominator; } }

        //constructors
        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }
            else
            {
                Numerator = numerator;
                Denominator = denominator;
            }
        }
        public Rational(int numerator) : this(numerator, 1) { }


        public static Rational operator +(Rational obj1, Rational obj2)
        {
            return obj1.Add(obj2);
        }

        public static Rational operator -(Rational obj1, Rational obj2)
        {
            return obj1.Add(new Rational(-obj2.Numerator, obj2.Denominator));
        }

        public static Rational operator *(Rational obj1, Rational obj2)
        {
            return obj1.Mul(obj2);
        }

        public static Rational operator /(Rational obj1, Rational obj2)
        {
            var wasReplaced = new Rational(obj2.Denominator, obj2.Numerator);
            return obj1.Mul(wasReplaced);
        }

        public static explicit operator double(Rational obj)
        {
            return obj.ToDouble;
        }

        public static explicit operator int(Rational obj)
        {
            return obj.ToInt;

        }

        public static implicit operator Rational(int fromInteger)
        {
            return new Rational(fromInteger);

        }


        public Rational Add(Rational obj)
        {
            if (Denominator == obj.Denominator)
            {
                return new Rational(Numerator + obj.Numerator, Denominator);
            }
            return new Rational((Numerator * obj.Denominator + obj.Numerator * Denominator),
                    (Denominator * obj.Denominator));
        }

        public Rational Mul(Rational obj)
        {
            return new Rational(Numerator * obj.Numerator, Denominator * obj.Denominator);
        }

        public void Reduce()
        {
            var greatestCommonDivisor = GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= greatestCommonDivisor;
            Denominator /= greatestCommonDivisor;
        }

        private int GreatestCommonDivisor(int numerator, int denominator)
        {
            return (denominator == 0) ? numerator
                : GreatestCommonDivisor(denominator, numerator % denominator); //recursion
        }

        public override bool Equals(object obj)
        {
            var rational = (Rational)obj;
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return ((Numerator == rational.Numerator) && (Denominator == rational.Denominator));
        }

        public override int GetHashCode()
        {
            return (int)ToDouble;
        }

        public override string ToString()
        {
            return string.Format("The result is: {0} / {1} = {2}", Numerator, Denominator, ToDouble);
        }
    }
}
