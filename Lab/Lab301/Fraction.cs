using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        private int _numer;
        private int _denom;
        private static int _count;

        public Fraction()
        {
            Numerator = 0;
            Denominator = 1;
            Count++;
        }

        public Fraction(Fraction a)
        {
            setValue(a._numer, a._denom);
            Count++;
        }

        public Fraction(int numer, int denom)
        {
            setValue(numer, denom);
            Count++;
        }

        public Fraction(int numer)
        {
            setValue(numer, 1);
            Count++;
        }

        public int Numerator
        {
            get
            {
                return _numer;
            }
            set
            {
                _numer = value;
            }
        }

        public int Denominator
        {
            get
            {
                return _denom;
            }
            set
            {
                if (value == 0)
                {
                    _denom = 1;
                }
                else
                {
                    _denom = value;
                }
            }
        }

        public static int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }

        public static Fraction operator +(Fraction f1,Fraction f2)
        {
            int numer=0, denom=0;
            numer = (f1._numer * f2._denom) + (f1._denom * f2._numer);
            denom = f1._denom * f2._denom;
            return new Fraction(numer / GCD(numer, denom), denom / GCD(numer, denom));
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int numer=0, denom=0;
            numer = (f1._numer * f2._denom) - (f1._denom * f2._numer);
            denom = f1._denom * f2._denom;
            return new Fraction(numer / GCD(numer, denom), denom / GCD(numer, denom));
        }

        public static Fraction operator ++(Fraction f1)
        {
            
            f1._numer = f1._numer + f1._denom;
            return f1;
        }

        public static Fraction operator +(Fraction f,int scale)
        {
            int numer=0, denom=0;
            numer = f._numer + (f._denom * scale);
            denom = f._denom ;
            return new Fraction(numer / GCD(numer, denom), denom / GCD(numer, denom));
        }

        public static Fraction operator -(int scale,Fraction f)
        {

            int numer=0, denom=0;
            numer = (f._denom * scale)-f._numer  ;
            denom = f._denom;
            return new Fraction(numer/GCD(numer,denom), denom / GCD(numer, denom));
        }

        public void setValue(int numer,int denom)
        {
           
            Numerator = numer/ GCD(numer, denom);
            Denominator = denom/ GCD(numer, denom);

        }

        public static int GCD(int numer,int denom)
        {
            int gcd = 1;

            for(int i = 1; i <= numer && i <= denom; i++)
            {
                if ( numer%i == 0 && denom%i == 0)
                {
                    gcd = i;
                }
            }
            return gcd;
        }

        public static bool operator ==(Fraction f1,Fraction f2)
        {

            return (f1._numer == f2._numer && f1._denom == f2._denom);
        }

        public static bool operator !=(Fraction f1,Fraction f2)
        {
            return (f1._numer != f2._numer || f1._denom != f2._denom);
        }

        public bool Equals(Fraction f1)
        {
            return (f1._numer ==_numer && f1._denom ==_denom);
        }

        public override string ToString()
        {
            string st;
            int numer, denom;
            double val;
            numer = Numerator / GCD(Numerator, Denominator);
            denom = Denominator / GCD(Numerator, Denominator);
            val = (double)numer/(double)denom;

            st = "[Rational:" + numer + "/" + denom + "], value=" + val +"]";
            return st;
        }
    }
}
