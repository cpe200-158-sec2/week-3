using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        private int _Number;
        private int _Denom;
        private static int _Count = 0;

        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        public int Denom
        {
            get { return _Denom; }
            set { _Denom = value; }
        }
        public static int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }
        public Fraction()
        {
            _Number = 0;
            _Denom = 1;
            _Count++;

        }
        public Fraction(Fraction a)
        {
            setValue(a.Number, a.Denom);
            _Count++;

        }
        public Fraction(int num = 0, int denom = 1)
        {
            setValue(num, denom);
            _Count++;
        }
        private void getlow()
        {
            int a;
            if (_Number > _Denom)
            {
                a = _Denom;
            }
            else
            {
                a = _Number;
            }
            while (a != 0)
            {
                if (_Number % a == 0 && _Denom % a == 0)
                {
                    _Number /= a;
                    _Denom /= a;
                    break;
                }
                a--;
            }
        }
        public void setValue(int num, int denom)
        {
            _Number = num;
            if (denom == 0)
            {
                _Denom = 1;
            }
            else
                _Denom = denom;
            getlow();
        }
        public static int GCD(int f, int s)
        {
            while (f != s)
            {
                if (f > s)
                {
                    f -= s;
                }
                else
                {
                    s -= f;
                }
            }
            return f;
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction((a._Number * b._Denom) + (b._Number * a._Denom), a._Denom * b._Denom);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction((a._Number * b._Denom) - (b._Number * a._Denom), a._Denom * b._Denom);
        }
        public static Fraction operator +(int a, Fraction b)
        {
            return new Fraction((a * b._Denom) + b._Number, b._Denom);
        }
        public static Fraction operator +(Fraction a, int b)
        {
            return new Fraction(a._Number + (b * a._Denom), a._Denom);
        }
        public static Fraction operator -(int a, Fraction b)
        {
            return new Fraction((a * b._Denom) - b._Number, b._Denom);
        }
        public static Fraction operator -(Fraction a, int b)
        {
            return new Fraction(a._Number - (b * a._Denom), a._Denom);
        }
        public static Fraction operator ++(Fraction a)
        {
            return new Fraction(a._Number + (a._Denom), a._Denom);
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            if (a._Number == b._Number && a._Denom == b._Denom)
            {
                return true;
            }
            else
                return false;
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            if (a._Number == b._Number && a._Denom == b._Denom)
            {
                return false;
            }
            else
            { return false; }
        }
        public override bool Equals(object obj)
        {
            Fraction c = (Fraction)obj;
            if (c.Number == Number && c.Denom == Denom) return true;
            else return false;
        }
        public override string ToString()
        {
            return "[Rational: " + Number + " / " + Denom + "], value = " + Convert.ToDouble(Number) / Convert.ToDouble(Denom) + "]";
        }

    }
}
