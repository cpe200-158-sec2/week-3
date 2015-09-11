using System;

namespace Lab301
{
    internal class Fraction
    {

        private int numer;

        public int Numer
        {
            get { return numer; }
            set { numer = value; }
        }

        private int denom;

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

        static private int count;

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
                if(min % i == 0 && max % i == 0)
                {
                    result = i;
                    break;
                }
            }
            
            return result;
        }

        public static Fraction operator +(Fraction left, Fraction right)
        {
            Fraction result = new Fraction();
            result.Numer = left.Numer * right.Denom + right.Numer * left.Denom;
            result.Denom = right.Denom * left.Denom;

            return result;
        }

        public static Fraction operator -(Fraction left, Fraction right)
        {
            Fraction result = new Fraction();
            result.Numer = left.Numer * right.Denom - right.Numer + left.Denom;
            result.Denom = right.Denom * left.Denom;

            return result;
        }

        public static Fraction operator -(int left,Fraction right)
        {
            Fraction result = new Fraction();
            result.Numer = right.Denom * left - right.Numer;
            result.Denom = right.Denom;

            return result;
        }

        public static Fraction operator ++(Fraction right)
        {
            Fraction result = new Fraction();
            result.Numer = right.Numer + right.Denom;
            result.Denom = right.Denom;

            return result;
        }

        public static Fraction operator +(Fraction right,int left)
        {
            Fraction result = new Fraction();
            result.Numer = right.Numer + right.Denom * left;
            result.Denom = right.Denom;

            return result;
        }

        public override string ToString()
        {
            return ("[Rational: " + numer + "/" + denom + "], value=" + (double)numer/denom + "");
        }

        public static bool operator ==(Fraction left ,Fraction right)
        {
            if (left.Denom == right.denom && left.Numer == right.numer)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Fraction left, Fraction right)
        {
            if (left.Denom == right.denom && left.Numer == right.numer)
            {
                return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            Fraction tmp = obj as Fraction;
            if(tmp.Denom == this.denom && tmp.Numer == this.numer)
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
//# implement the fraction class according to the following requirements:

//## propeties:
//- numer: numerator
//- denom: denominator(default=1, cannot be 0)
//- count: counting #objects of this class (static)
//note: numerator and denominator have to in the minimal form.
//      see r3 and r6.

//## constructors:
//- fraction (): default constructor
//- fraction(fraction a): copy constructor
//- fraction(numerator, denominator)
//note: increment the count property when an object is created

//## methods
//- setvalue: set fraction value
//- gcd: calculate greatest common divisor of two integers(static)

