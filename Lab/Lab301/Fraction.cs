using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        private int Numer;

        public int numer
        {
            get { return Numer; }
            set { Numer = value; }
        }

        private int Denom;

        public int denom
        {
            get { return Denom; }
            set
            {
                if (value == 0)
                    Denom = 1;
                else
                    Denom = value;
            }
        }

        private static int count = 0;

        public static int Count
        {
            get { return count; }
            set { count = value; }
        }


        public Fraction()
        {
            numer = 0;
            denom = 1;
            Count++;
        }

        public Fraction(Fraction x)
        {
            numer = x.numer;
            denom = x.denom;
            //Count++;
        }

        public Fraction(int x)
        {
            numer = x;
            denom = 0;
            Count++;
        }

        public Fraction(int x, int y)
        {
            numer = x;
            denom = y;
            Count++;
        }



        /*public static Fraction operator =(Fraction L , Fraction R)
        {
            return new Fraction(L.numer = R.numer, L.denom = R.denom);
        }*/

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

        public void setValue(int x, int y)
        {
            this.numer = x;
            this.denom = y;
        }

        public static Fraction operator +(Fraction L, Fraction R)
        {
            return new Fraction((L.Numer * R.Denom) + (R.Numer * L.Denom), L.Denom * R.Denom);
        }

        public static Fraction operator -(Fraction L, Fraction R)
        {
            return new Fraction((L.numer * R.denom) - (R.numer * L.denom), L.denom * R.denom);
        }

        public static Fraction operator +(Fraction L, int i)
        {
            return new Fraction(L.numer + (i * L.denom), L.denom * 1);
        }

        public static Fraction operator -(Fraction L, int i)
        {
            return new Fraction(L.numer - (i * L.denom), L.denom * 1);
        }

        public static Fraction operator +(int i, Fraction R)
        {
            return new Fraction(R.numer + (i * R.denom), R.denom * 1);
        }

        public static Fraction operator -(int i, Fraction R)
        {
            return new Fraction((i * R.denom) - R.numer, R.denom * 1);
        }

        public static Fraction operator ++(Fraction L)
        {
            return new Fraction(L.numer + (1 * L.denom), L.denom * 1);
        }

        public static bool operator ==(Fraction L, Fraction R)
        {
            if (L.Numer / L.Denom == R.Numer / R.Denom)
                return true;
            else return false;
        }

        public static bool operator !=(Fraction L, Fraction R)
        {
            if (L.Numer / L.Denom != R.Numer / R.Denom)
                return true;
            else return false;
        }

        public override bool Equals(object obj)
        {
            Fraction tmp = obj as Fraction;
            if ((System.Object)tmp == obj)
                return true;
            else return false;
        }

        public override string ToString()
        {
            double val = (double)numer / denom;
            return string.Format("[Rational: {0}/{1}], value={2}]", numer / GCD(numer, denom), denom / GCD(numer, denom), val);
        }


    }
}
