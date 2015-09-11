using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        private int numer;
        private int denom;
        private static int count;

        public override string ToString()
        {
            return string.Format("[Rational: {0}/{1}], value={2}]", numer / GCD(numer, denom), denom / GCD(numer, denom), (double)numer / (double)denom);
        }

        public Fraction()
        {
            Numer = 0;
            Denom = 1;
            Count++;
        }

        public Fraction(Fraction a)
        {
            Numer = a.numer;
            Denom = a.denom;
            Count++;
        }

        public Fraction(int _numer =0 ,int _denom =1)
        {
            Numer = _numer;
            Denom = _denom;
            Count++;
        }

        public int Numer
        {
            get
            {
                return numer;
            }
            set
            {
                numer = value;
            }
        }

        public int Denom
        {
            get
            {
                return denom;
            }
            set
            {
                if (value == 0)
                    denom = 1;
                else denom = value;
            }
        }

        public static int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }

        public void setValue(int _numer ,int _denom)
        {
            Numer = _numer;
            Denom = _denom;
        }

        public static int GCD(int a, int b)
        {
            if (a == 0) return b;
            return GCD(b % a, a);
        }

        public bool Equals(Fraction c)
        {
            return (numer == c.numer && denom == c.denom);
        }

        public static Fraction operator +(Fraction c1, Fraction c2)
        {
            return new Fraction(c1.numer * c2.denom + c1.denom * c2.numer, c1.denom * c2.denom);
        }

        public static Fraction operator -(Fraction c1, Fraction c2)
        {
            return new Fraction(c1.numer * c2.denom - c1.denom * c2.numer, c1.denom * c2.denom);
        }

        public static Fraction operator ++(Fraction c)
        {
            c.numer += c.denom;
            return c;
        }

        public static Fraction operator +(Fraction c, int b)
        {
            return new Fraction(c.denom * b + c.numer, c.denom);
        }

        public static Fraction operator +(int a, Fraction c)
        {
            return new Fraction(a * c.denom + c.numer, c.denom);
        }

        public static Fraction operator -(Fraction c, int b)
        {
            return new Fraction(c.numer - b * c.denom, c.denom);
        }

        public static Fraction operator -(int a, Fraction c)
        {
            return new Fraction(a * c.denom - c.numer, c.denom);
        }

        public static bool operator ==(Fraction c1, Fraction c2)
        {
            return (c1.numer == c2.numer && c1.denom == c2.denom);
        }

        public static bool operator !=(Fraction c1, Fraction c2)
        {
            return (c1.numer != c2.numer && c1.denom != c2.denom);
        }

    }
}
