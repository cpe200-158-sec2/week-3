using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        private int _numerator = 0;
        private int _denominator = 1;
        private static int _count = 0;
        public Fraction()
        {
            setValue(0, 1);
            Count++;
        }
        public Fraction(Fraction a)
        {
            setValue(a.Numerator, a.Denominator);
            Count++;
        }
        public Fraction(int numerator)
        {
            setValue(numerator, 1);
            Count++;
        }
        public Fraction(int numerator, int denominetor)
        {
            setValue(numerator, denominetor);
            Count++;
        }
        public void setValue(int numerator, int denominetor)
        {
            if (denominetor != 0)
            {
                Numerator = (numerator / GCD(numerator, denominetor));
                Denominator = (denominetor / GCD(numerator, denominetor));
            }

            else
            {
                Numerator = numerator;
                Denominator = 1;
            }
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction c = new Fraction();
            c.Numerator = (a.Numerator * b.Denominator) + (b.Numerator * a.Denominator);
            c.Denominator = (a.Denominator * b.Denominator);
            c.setValue(c.Numerator, c.Denominator);
            return c;
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction c = new Fraction();
            c.Numerator = (a.Numerator * b.Denominator) - (b.Numerator * a.Denominator);
            c.Denominator = (a.Denominator * b.Denominator);
            c.setValue(c.Numerator, c.Denominator);
            return c;
        }
        public static Fraction operator +(int a, Fraction b)
        {
            Fraction c = new Fraction();
            c.Numerator = (a * b.Denominator) + (b.Numerator);
            c.Denominator = b.Denominator;
            c.setValue(c.Numerator, c.Denominator);
            return c;
        }
        public static Fraction operator +(Fraction b, int a)
        {
            Fraction c = new Fraction();
            c.Numerator = (a * b.Denominator) + (b.Numerator);
            c.Denominator = b.Denominator;
            c.setValue(c.Numerator, c.Denominator);
            return c;
        }
        public static Fraction operator -(int a, Fraction b)
        {
            Fraction c = new Fraction();
            c.Numerator = (a * b.Denominator) - (b.Numerator);
            c.Denominator = b.Denominator;
            c.setValue(c.Numerator, c.Denominator);
            return c;
        }
        public static Fraction operator -(Fraction b, int a)
        {
            Fraction c = new Fraction();
            c.Numerator = (b.Numerator) - (a * b.Denominator);
            c.Denominator = b.Denominator;
            c.setValue(c.Numerator, c.Denominator);
            return c;
        }
        public static Fraction operator ++(Fraction b)
        {
            b.Numerator = (b.Numerator + b.Denominator);
            b.Denominator = b.Denominator;
            b.setValue(b.Numerator, b.Denominator);
            return b;
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            return ((a.Numerator == b.Numerator) && (a.Denominator == b.Denominator));
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            return ((a.Numerator != b.Numerator) || (a.Denominator != b.Denominator));
        }
        public bool Equals(Fraction a)
        {
            return ((a.Numerator == Numerator) && (a.Denominator == Denominator)); ;
        }
        public override string ToString()
        {
            return string.Format("[Rational: {0}/{1}], value={2}]", Numerator, Denominator, (double)Numerator / Denominator);
        }
        static public int Count
        {
            set { _count++; }
            get { return _count; }
        }
        static public int GCD(int a, int b)
        {
            int temp;
            while (b != 0)
            {
                temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }
        public int Numerator
        {
            get { return _numerator; }
            set { _numerator = value; }
        }
        public int Denominator
        {
            get { return _denominator; }
            set
            {
                if (value != 0) _denominator = value;
                else _denominator = 1;
            }
        }

    }
}
