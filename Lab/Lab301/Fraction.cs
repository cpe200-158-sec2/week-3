using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        private int _numerator;
        private int _denoniation;
        private static int _couting;

        public Fraction()
        {

            this.numer = 0;
            this.demon = 1;
            _couting++;
        }
        public Fraction(Fraction a)
        {
            this.numer = a.numer;
            this.demon = a.demon;
            _couting++;
        }
        public Fraction(int n, int d)
        {
            this.numer = n;
            this.demon = d;
            _couting++;
        }
        public Fraction(int n)
        {
            this.numer = n;
            this.demon = 1;
            _couting++;
        }
        public int numer
        {
            get { return _numerator; }
            set { _numerator = value; }
        }
        public int demon
        {
            get { return _denoniation; }
            set
            {
                if (value >= 1)
                {
                    _denoniation = value;
                }
                else
                {
                    _denoniation = 1;
                }
            }
        }
        public static int Count
        {
            get { return _couting; }
            set { _couting = value; }
        }

        public void setValue(int a, int b)
        {
            int j;
            j = GCD(a, b);
            this.numer = a / j;
            this.demon = b / j;

        }

        public static int GCD(int a, int b)
        {
            int num;
            while (b != 0)
            {
                num = a % b;
                a = b;
                b = num;
            }
            return a;
        }


        public static Fraction operator +(Fraction a, Fraction b)
        {
            int x = 0;
            int y = 0;
            int z = 0;
            x = (a.numer * b.demon) + (b.numer * a.demon);
            y = a.demon * b.demon;
            z = GCD(x, y);
            return new Fraction(x / z, y / z);
        }

        public static Fraction operator +(Fraction a, int b)
        {
            int x = 0;
            int y = 0;
            int z = 0;
            x = a.numer + b * a.demon;
            y = a.demon;
            z = GCD(x, y);
            return new Fraction(x / z, y / z);
        }
        public static Fraction operator -(int a, Fraction b)
        {
            int x = 0;
            int y = 0;
            int z = 0;
            x = a*(b.demon)-b.numer ;
            y = b.demon;
            z = GCD(x, y);
            return new Fraction(x / z, y / z);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            int x = 0;
            int y = 0;
            int z = 0;
            x = (a.numer * b.demon) - (b.numer * a.demon);
            y = a.demon * b.demon;
            z = GCD(x, y);
            return new Fraction(x / z, y / z);
        }


        public static Fraction operator ++(Fraction a)
        {
            int x = 0;
            int y = 0;
            int z = 0;
            x = (a.numer + a.demon);
            y = a.demon;
            z = GCD(x, y);
            return a;
        }
        public bool Equals(Fraction a)
        {
            return (this == a);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return (a.numer == b.numer && a.demon == b.demon);
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            return (a.numer != b.numer || a.demon != b.demon);
        }
        public override string ToString()
        {
            int x = _numerator;
            int y = _denoniation;
            double c = (double)x / y;
            return ("[Rational:" + x + "/" + y + "],value=" + c + "]");
        }

    }
    }
