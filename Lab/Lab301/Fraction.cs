using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {

        //Propeties
        private int _numerator;
        private int _denominator;
        private static int _counting=0;

        public int Numerator
        {
            get { return _numerator; }
            set { _numerator = value; }
        }

        public int Demominator
        {
            get { return _denominator; }
            set
            {
                if (value == 0)
                {
                    _denominator = 1;
                }
                else
                {
                    _denominator = value;
                }
            }
        }

        public static int Count
        {
            get { return _counting; }
        }

        //Constructors
        public Fraction()
        {
            this.Numerator = 0;
            this.Demominator = 1;
            _counting++;
        }

        public Fraction(int a)
        {
            this.Numerator = a;
            this.Demominator = 1;
            _counting++;
        }

        public Fraction(Fraction a)
        {
            this.Numerator = a.Numerator;
            this.Demominator = a.Demominator;
            _counting++;
        }

        public Fraction(int n, int d)
        {
            this.Numerator = n;
            this.Demominator = d;
            _counting++;
        }

        //Methods
        public void setValue(int n, int d)
        {
            this.Numerator = n;
            this.Demominator = d;
        }

        public static int GCD(int n, int d)
        {
            if(n % d == 0)
            {
                return d;
            }
            else
            {
                return GCD(d, n % d);
            }
        }

        //Operator Overloading
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            Fraction temp = new Fraction();
            temp.Numerator = (f1.Numerator * f2.Demominator) + (f2.Numerator * f1.Demominator);
            temp.Demominator = f1.Demominator * f2.Demominator;
            return temp;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            Fraction temp = new Fraction();
            temp.Numerator = (f1.Numerator * f2.Demominator) - (f2.Numerator * f1.Demominator);
            temp.Demominator = f1.Demominator * f2.Demominator;
            return temp;
        }

        public static Fraction operator -(int n, Fraction f)
        {
            Fraction temp = new Fraction();
            temp.Numerator = (n * f.Demominator) - f.Numerator;
            temp.Demominator = f.Demominator;
            return temp;
        }

        public static Fraction operator +(Fraction f, int n)
        {
            Fraction temp = new Fraction();
            temp.Numerator = f.Numerator + (n * f.Demominator);
            temp.Demominator = f.Demominator;
            return temp;
        }

        public static Fraction operator ++(Fraction f)
        {
            f.Numerator = f.Numerator + f.Demominator;
            return f;
        }

        public override string ToString()
        {
            double ans = (double)this.Numerator / (double)this.Demominator;
            int gcd = GCD(this.Numerator, this.Demominator);
            string s = "[Rational: " + Numerator/gcd + "/" + Demominator/gcd + "] , value=" + ans + "]";
            return s;
        }

        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return ((f1.Numerator == f2.Numerator) && (f1.Demominator == f2.Demominator));
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return ((f1.Numerator != f2.Numerator) || (f1.Demominator != f2.Demominator));
        }

        public bool Equals(Fraction f)
        {
            return ((f.Numerator == this.Numerator) && (f.Demominator == this.Demominator));
        }
    }
}
