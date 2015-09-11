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
        private int _denom=1;
        static private int _count=0;

        static public int Count
        {
            get
            {
                return _count;
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
                _denom = value;
            }
        }
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

        public Fraction(Fraction a)
        {
            setValue(a.Numer, a.Denom);
            _count++;
        }   
        public Fraction(int num=0,int dom=1)
        {
            setValue(num, dom);
            _count++;
        }

        private void getBetter()
        {
            int a;
            if (_numer > _denom)
            {
                a = _denom;
            }
            else
            {
                a = _numer;
                
            }
            while (a != 0)
            {
                if (_numer % a == 0 && _denom % a == 0)
                {
                    _numer /= a;
                    _denom /= a;
                    break;
                }
                a--;
            }
        }
        public void setValue(int num,int dom) {
            _numer = num;
            if (dom > 0)
                _denom = dom;
            else _denom = 1;
            getBetter();
        }
        static public int LCM(int a,int b) {
            int c;
            if (a > b) c = a; else c = b;
            while (c % a != 0 || c % b != 0)
                c++;
            return c;
        }
        static public int GCD(int a, int b)
        {
            while (b != a)
            {
                if (a > b)
                    a = a - b;
                else b = b - a;
            }
            return a;
        }


        public override string ToString()
        {
            return "[Rational: "+Numer+" / "+Denom+"], value = "+Convert.ToDouble(Numer)/Convert.ToDouble(Denom)+"]";
        }
        public override bool Equals(Object a)
        {
            Fraction c = (Fraction)a;
            if (c.Numer == Numer && c.Denom == Denom) return true;
            else return false;
        }

        public static Fraction operator+ (Fraction a,Fraction b)
        {
            Fraction c = new Fraction();
            int lcm = LCM(a.Denom, b.Denom);
            c.setValue(a.Numer * (lcm / a.Denom) + b.Numer * (lcm / b.Denom), lcm);
            return c;
        }
        public static Fraction operator -(Fraction a, Fraction b) {
            Fraction c = new Fraction();
            int lcm = LCM(a.Denom, b.Denom);
            c.setValue(a.Numer * (lcm / a.Denom) - b.Numer * (lcm / b.Denom), lcm);
            return c;
        }
        public static Fraction operator++(Fraction a)
        {
            a.setValue(a.Numer + a.Denom, a.Denom);
            return a;
        }
        public static Fraction operator +(Fraction a, int b)
        {
            Fraction c = new Fraction(a);
            c.setValue(c.Numer + b*c.Denom, c.Denom);
            return c;
        }
        public static Fraction operator -(int a, Fraction b)
        {
            Fraction c = new Fraction(b);
            c.setValue(a * c.Denom - c.Numer, c.Denom);
            return c;
        }
        public static bool operator ==(Fraction a,Fraction b)
        {
            if (a.Numer == b.Numer && a.Denom == b.Denom) return true;
            else return false;
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            if (a.Numer == b.Numer && a.Denom == b.Denom) return false;
            else return true;
        }
    }
}
