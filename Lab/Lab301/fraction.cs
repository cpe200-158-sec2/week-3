using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        private int _Numer;
        private int _Denom;
        private static int _Count;

        public int Numer
        {
            get { return _Numer; }
            set { _Numer = value; }
        }
        public int Denom
        {
            get { return _Denom; }
            set
            {
                if (value == 0)
                {
                    value = 1;
                    _Denom = value;
                }
                else
                { _Denom = value; }
            }
        }
        public static int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }

        public Fraction()
        {
            Numer = 0;
            Denom = 1;
            Count++;
        }
        public Fraction(int x)
        {
            Numer = x;
            Denom = 1;
            Count++;
        }
        public Fraction(int x, int y)
        {
            Numer = x;
            Denom = y;
            Count++;
        }
        public Fraction(Fraction x)
        {
            Numer = x.Numer;
            Denom = x.Denom;
        }
        public Fraction setValue(int n, int d)
        {
            this.Numer = n;
            this.Denom = d;
            return this;
        }
        public bool Equals(Fraction x)
        {
            return (this.Numer / this.Denom == x.Numer / x.Denom);
        }
        public static int GCD(int x, int y)
        {
            int Remainder;

            while (y != 0)
            {
                Remainder = x % y;
                x = y;
                y = Remainder;
            }

            return x;
        }
        public static Fraction operator +(Fraction x, Fraction y)
        {
            return new Fraction(x.Numer * y.Denom + x.Denom * y.Numer, x.Denom * y.Denom);
        }
        public static Fraction operator -(Fraction x, Fraction y)
        {
            return new Fraction(x.Numer * y.Denom - x.Denom * y.Numer, x.Denom * y.Denom);
        }
        public static Fraction operator ++(Fraction x)
        {
            return new Fraction(x.Numer + x.Denom, x.Denom);

        }
        public static Fraction operator +(Fraction x, int a)
        {
            return new Fraction(x.Numer + a * x.Denom, x.Denom);
        }
        public static Fraction operator -(Fraction x, int a)
        {
            return new Fraction(x.Numer - a * x.Denom, x.Denom);
        }
        public static Fraction operator +(int a, Fraction x)
        {
            return new Fraction(x.Numer + a * x.Denom, x.Denom);
        }
        public static Fraction operator -(int a, Fraction x)
        {
            return new Fraction(a * x.Denom - x.Numer, x.Denom);
        }
        public static bool operator ==(Fraction x, Fraction y)
        {
            if (x.Numer == y.Numer && x.Denom == y.Denom)
                return true;
            else
                return false;
        }
        public static bool operator !=(Fraction x, Fraction y)
        {
            if (x.Numer != y.Numer && x.Denom != y.Denom)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return string.Format("[Rational: {0}/{1}], value={2}]",
            this.Numer / GCD(this.Numer, this.Denom), this.Denom / GCD(this.Numer, this.Denom), (double)this.Numer / (double)this.Denom);
        }
    }
}