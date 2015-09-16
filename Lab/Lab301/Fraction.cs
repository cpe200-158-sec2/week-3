using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {

            //member
            private int _numer;
            private int _denom;
            private static int _count = 0;


            //properties
            public int Numer
            {
                get { return _numer; }
                set { _numer = value; }
            }
            public int Denom
            {
                get { return _denom; }
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
                get { return _count; }
            }

            //constructor
            public Fraction()
            {
                this.Numer = 0;
                this.Denom = 1;
                _count++;
            }
            public Fraction(Fraction a)
            {
                this.Numer = a._numer;
                this.Denom = a._denom;
                _count++;
            }
            public Fraction(int a)
            {
                this.Numer = a;
                this.Denom = 1;
                _count++;
            }
            public Fraction(int a, int b)
            {
                this.Numer = a;
                this.Denom = b;
                _count++;
            }

            //methods
            public void setValue(int a, int b)
            {   //call prop to receive value
                this.Numer = a;
                this.Denom = b;
            }
            public static int GCD(int a, int b)
            {
                if (a % b == 0)
                {
                    return b;
                }
                else
                {
                    return GCD(b, a % b);
                }
            }

            //operator
            public static Fraction operator +(Fraction a, Fraction b)
            {
                Fraction tmp = new Fraction();
                tmp.Numer = ((a.Numer * b.Denom) + (b.Numer * a.Denom));
                tmp.Denom = a.Denom * b.Denom;
                return tmp;
            }


            public static Fraction operator +(Fraction a, int b)
            {
                Fraction tmp = new Fraction();
                tmp.Numer = a.Numer + (b * a.Denom);
                tmp.Denom = a.Denom;
                return tmp;
            }

            public static Fraction operator -(Fraction a, Fraction b)
            {
                Fraction tmp = new Fraction();
                tmp.Numer = ((a.Numer * b.Denom) - (b.Numer * a.Denom));
                tmp.Denom = a.Denom * b.Denom;
                return tmp;
            }
            public static Fraction operator -(int b, Fraction a)
            {
                Fraction tmp = new Fraction();
                tmp.Numer = (b * a.Denom) - a.Numer;
                tmp.Denom = a.Denom;
                return tmp;
            }
            public static Fraction operator ++(Fraction a)
            {
                a.Numer = a.Numer + a.Denom;
                return a;
            }

            public static bool operator ==(Fraction a, Fraction b)
            {
                return ((a.Numer == b.Numer) && (a.Denom == b.Denom));
            }
            public static bool operator !=(Fraction a, Fraction b)
            {
                return ((a.Numer != b.Numer) || (a.Denom != b.Denom));
            }
            public bool Equals(Fraction a)
            {
                return ((a.Numer == this.Numer) && (a.Denom == this.Denom));
            }
            //write
            public override string ToString()
            {
                double ans = (double)this.Numer / (double)this.Denom;
                int gcd = GCD(this.Numer, this.Denom);
                string s = "[Rational: " + Numer / gcd + "/" + Denom / gcd + "] , value=" + ans + "]";
                return s;
            }

        }
    }


