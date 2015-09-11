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
        private static int _count=0;

        public int Numer
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
        public int Denom
        {
            get
            {
                return _denom;
            }
            set
            {
                if(_denom == 0)
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
        public Fraction()
        {
            _numer = 0;
            _denom = 1;
            _count++;
        }
        public Fraction(Fraction a)
        {
            _numer = a._numer;
            _denom = a._denom;
            _count++; 
        }
        public Fraction(int n, int d)
        {
            _numer = n;
            _denom = d;
            _count++;
        }
        public Fraction (int i)
        {
            _numer = i;
            _denom = 1;
            _count++;
        }
        public void setValue(int n, int d)
        {
            _numer = n;
            if(d == 0)
            {
                d = 1;
            }
            _denom = d;
        }
        public static int GCD(int num, int de)
        {
            if(de == 0)
            {
                return num;
            }
            else
            {
                return GCD(de, num % de);
            }
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction((a._numer * b._denom) + (a._denom * b._numer), a._denom * b._denom);
        }
        public static Fraction operator +(Fraction a, int i)
        {
            return new Fraction((i * a._denom) + a._numer, a._denom);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction((a._numer * b._denom) - (a._denom * b._numer), a._denom * b._denom);
        }
        public static Fraction operator -(int i, Fraction e)
        {
            return new Fraction((i * e._denom) - e._numer, e._denom);
        }
        public static Fraction operator ++(Fraction x)
        {
            x._numer += x._denom;
            return x;
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            return (a._numer == b._numer && a._denom == b._denom);
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            return (a._numer != b._numer || a._denom != b._denom);
        }
        public bool Equals(Fraction a)
        {
            return (this == a);
        }
        public override string ToString()
        {
            int x = GCD(_numer, _denom);
            int num=this._numer/x;
            int de = this._denom / x;
            double val = (double)num / (double)de;
            string s = "[Rational: "+ num+"/"+de+"], value="+val+"]";
            return s;
        }
    }
}
