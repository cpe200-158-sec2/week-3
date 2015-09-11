using System;

namespace Lab301
{
    class Fraction
    {

        private int numer;
        private int denom;
        static private int count;
        public int Numer
        {
            get { return numer; }
            set { numer = value; }
        }

    
        public int Denom
        {
            get { return denom; }
            set
            {
                if (value != 0)
                    denom = ReduceFraction(value);
                else
                    denom = 1;
            }
        }

     

        static public int Count
        {
            get { return count; }
        }

        public Fraction()
        {
            count++;
            this.numer = 0;
            this.denom = 1;
        }

        public Fraction(int numerator)
        {
            count++;
            this.Numer = numerator;
            this.denom = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            count++;
            this.Numer = numerator;
            this.Denom = denominator;
        }

        public Fraction(Fraction clone)
        {
            this.Numer = clone.Numer;
            this.Denom = clone.Denom;
        }

        public void setValue(int v1, int v2)
        {
            this.Numer = v1;
            this.Denom = v2;
        }

        public static int GCD(int x, int y)
        {
            int max = Math.Max(x, y);
            int min = Math.Min(x, y);
            int result = 1;
            for (int i = max; i != 1; i--)
            {
                if (min % i == 0 && max % i == 0)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public static Fraction operator +(Fraction l, Fraction r)
        {
            Fraction result = new Fraction();
            result.Numer = l.Numer * r.Denom + r.Numer * l.Denom;
            result.Denom = r.Denom * l.Denom;

            return result;
        }

        public static Fraction operator -(Fraction l, Fraction r)
        {
            Fraction result = new Fraction();
            result.Numer = l.Numer * r.Denom - r.Numer + l.Denom;
            result.Denom = r.Denom * l.Denom;

            return result;
        }

        public static Fraction operator -(int l, Fraction r)
        {
            Fraction result = new Fraction();
            result.Numer = r.Denom * l - r.Numer;
            result.Denom = r.Denom;

            return result;
        }

        public static Fraction operator ++(Fraction r)
        {
            Fraction result = new Fraction();
            result.Numer = r.Numer + r.Denom;
            result.Denom = r.Denom;

            return result;
        }

        public static Fraction operator +(Fraction r, int l)
        {
            Fraction result = new Fraction();
            result.Numer = r.Numer + r.Denom * l;
            result.Denom = r.Denom;

            return result;
        }

        public override string ToString()
        {
            return ("[Rational: " + numer + "/" + denom + "], value=" + (double)numer / denom + "");
        }

        public static bool operator ==(Fraction l, Fraction r)
        {
            if (l.Denom == r.denom && l.Numer == r.numer)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Fraction l, Fraction r)
        {
            if (l.Denom == r.denom && l.Numer == r.numer)
            {
                return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            Fraction tmp = obj as Fraction;
            if (tmp.Denom == this.denom && tmp.Numer == this.numer)
            {
                return true;
            }
            return false;
        }

        private int ReduceFraction(int d)
        {
            int divider = GCD(numer, d);
            numer = numer / divider;
            d = d / divider;

            return d;
        }
    }
}