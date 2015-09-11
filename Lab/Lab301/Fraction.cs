using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        private int _numer,_denom ;
        private static int _count=0 ;

        public int Numer
        {
            get { return _numer; }
            set { _numer = value; }
        }
        public int Denom
        {
            get { return _denom; }
            set { _denom = value; }
        }
        public static int Count
        {
            get { return _count; }
        }

        public Fraction()
        {
            _count++;
            this._numer = 0;
            this._denom = 1;
        }
        public Fraction(int num)
        {
            _count++;
            this.Numer = num;
            this._denom = 1;
        }
        public Fraction(int num, int den)
        {
            _count++;
            this.Numer = num/GCD(num,den);
            this.Denom = den/GCD(num,den);
        }
        public Fraction(Fraction a)
        {
            this.Numer = a.Numer;
            this.Denom = a.Denom;
        }

        public void setValue(int x, int y)
        {
            this.Numer = x;
            if (y == 0) { y = 1; }
            this.Denom = y;
        }

        static public int GCD(int x, int y)
        {
            int Answer = 0;
            for (int i = x; i > 0; i--)
            {
                if (x % i == 0 && y % i == 0)
                {
                    Answer = i;
                    break;
                }
            }
            return Answer;
        }
        public static Fraction operator +(Fraction x, Fraction y)
        {
            Fraction result = new Fraction();
            result.Numer = x.Numer * y.Denom + y.Numer * y.Denom;
            result.Denom = y.Denom * x.Denom;

            return result;
        }

        public static Fraction operator -(Fraction x, Fraction y)
        {
            Fraction result = new Fraction();
            result.Numer = x.Numer * y.Denom - y.Numer * x.Denom;
            result.Denom = y.Denom * x.Denom;

            return result;
        }

        public static Fraction operator -(int x, Fraction y)
        {
            Fraction a = new Fraction();
            a.Numer = y.Denom * x - y.Numer;
            a.Denom = y.Denom;

            return a;
        }

        public static Fraction operator ++(Fraction x)
        {
            Fraction a = new Fraction();
            a.Numer = x.Numer + x.Denom;
            a.Denom = x.Denom;

            return a;
        }

        public static Fraction operator +(Fraction x, int y)
        {
            Fraction a = new Fraction();
            a.Numer = x.Numer + x.Denom * y;
            a.Denom = x.Denom;

            return a;
        }

        public override string ToString()
        {
            return ("[Rational: " + _numer + "/" + _denom + "], value=" + (double)_numer / _denom + "");
        }

        public static bool operator ==(Fraction x, Fraction y)
        {
            if (x.Denom == y._denom && x.Numer == y._numer) { return true; }
            return false;
        }

        public static bool operator !=(Fraction x, Fraction y)
        {
            if (x.Denom == y._denom && x.Numer == y._numer) { return false; }
            return true;
        }

        public override bool Equals(object a)
        {
            Fraction tmp = a as Fraction;
            if (tmp.Denom == this._denom && tmp.Numer == this._numer) { return true; }
            return false;
        }

        private int ReduceFraction(int d)
        {
            int divider = GCD(_numer, d);
            _numer = _numer / divider;
            d = d / divider;

            return d;
        }
    }
}

