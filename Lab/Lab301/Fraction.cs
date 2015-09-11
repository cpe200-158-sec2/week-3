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
        private int _Demon;
        static private int _Count = 0;

        public int Numer
        {
            get
            {
                return _Numer;
            }
            set
            {
                _Numer = value;
            }
        }

        public int Demon
        {
            get
            {
                return _Demon;
            }
            set
            {
                _Demon = value;
            }
        }

        static public int Count
        {
            get
            {
                return _Count;
            }
        }
            
        public Fraction()
        {
            setValue(0,1);
            _Count++;
        }

        public Fraction(Fraction a)
        {
            setValue(a.Numer,a.Demon);
            _Count++;
        }

        public Fraction(int numerator)
        {
            setValue(numerator , 1);
            _Count++;
        }

        public Fraction(int numerator , int denominator)
        {
            setValue(numerator, denominator);
            _Count++;
        }
        
        public void setValue(int num , int denom)
        {
            _Numer = num;
            if (denom > 0)
            {
                _Demon = denom;
            }
            else _Demon = 1;

            getDivider();
        }
        public override string ToString()
        {
            return "[Rational: "+Numer+" / "+Demon+"], value="+Convert.ToDouble(Numer) / Convert.ToDouble(Demon)+"]";
        }

        public static Fraction operator+(Fraction x , Fraction y)
        {
            Fraction a = new Fraction();
            a.setValue((x.Numer * y.Demon) + (y.Numer * x.Demon), (x.Demon * y.Demon));
            return a;
        }

        public static Fraction operator -(Fraction x, Fraction y)
        {
            Fraction a = new Fraction();
            a.setValue((x.Numer * y.Demon) - (y.Numer * x.Demon), (x.Demon * y.Demon));
            return a;
        }

        public static Fraction operator ++(Fraction x)
        {
            x.setValue(x.Numer+x.Demon,x.Demon);
            return x;
        }

        public static Fraction operator +(Fraction x, int y)
        {
            Fraction a = new Fraction();
            a.setValue((x.Numer+(y*x.Demon)), x.Demon);
            return a;
        }

        public static Fraction operator -(int x, Fraction y)
        {
            Fraction a = new Fraction();
            a.setValue((x*y.Demon)-y.Numer,y.Demon);
            return a;
        }

        public static bool operator ==(Fraction x , Fraction y)
        {
            if (x.Numer == y.Numer && x.Demon == y.Demon) return true;
            else return false;
        }

        public static bool operator !=(Fraction x, Fraction y)
        {
            if (x.Numer != y.Numer && x.Demon != y.Demon) return true;
            else return false;
        }

        public override bool Equals(object obj)
        {
            Fraction a = (Fraction)obj;
            if (a.Numer == Numer && a.Demon == Demon) return true;
            else return false;
        }

        static public int GCD(int a,int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            if (a > b) return GCD(a % b, b);
            else return GCD(a, b % a);
        }

        public void getDivider()
        {
            int divide;
            if (_Numer < _Demon)
            {
                divide = _Numer;
            }
            else
            {
                divide = _Demon;
            }

            while(divide>0)
            {
                if(_Numer % divide == 0 && _Demon % divide == 0)
                {
                    _Numer = _Numer / divide;
                    _Demon = _Demon / divide;
                    break;
                }
                divide--;
            }
        }

    }
}
