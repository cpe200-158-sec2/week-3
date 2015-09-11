using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        private int numer;
        private int denom = 1;
        private static int count = 0;
       
        public int Numerator
        {
            get { return numer; }
            set { numer = value; }
        }
        public int Denominator
        {
            get { return denom; }
            set { denom = value; }
        }
        public static int Count
        {
            get { return count; }
        }
        public Fraction()
        {
            numer = 0;
            denom = 1;
            count++;
        }
        public Fraction(Fraction a)
        {
            setValue(a.numer, a.denom);
            count++;
        }
        public Fraction(int numer,int denom = 1)
        {
            setValue(numer, denom);
            count++;
        }

        private void getBetter()
        {
            int a;
            if (numer > denom)
            {
                a = denom;
            }
            else
            {
                a = numer;

            }
            while (a != 0)
            {
                if (numer % a == 0 && denom % a == 0)
                {
                    numer /= a;
                    denom /= a;
                    break;
                }
                a--;
            }
        }
        public void setValue(int num, int dom)
        {
            numer = num;
            if (dom > 0)
                denom = dom;
            else denom = 1;
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

            return "[Rational: " + Numerator + " / " + Denominator + "], value = " + Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator) + "]";
        }
        public override bool Equals(Object a)
        {
            Fraction c = (Fraction)a;
            if (c.Numerator == Numerator && c.Denominator == Denominator) return true;
            else return false;
        }

        public static Fraction operator+ (Fraction a,Fraction b)
        {
            Fraction c = new Fraction();
            int lcm = LCM(a.Denominator, b.Denominator);
            c.setValue(a.Numerator * (lcm / a.Denominator) + b.Numerator * (lcm / b.Denominator), lcm);
            return c;
        }
        public static Fraction operator -(Fraction a, Fraction b) {
            Fraction c = new Fraction();
            int lcm = LCM(a.Denominator, b.Denominator);
            c.setValue(a.Numerator * (lcm / a.Denominator) - b.Numerator * (lcm / b.Denominator), lcm);
            return c;
        }
        public static Fraction operator++(Fraction a)
        {
            a.setValue(a.Numerator + a.Denominator, a.Denominator);
            return a;
        }
        public static Fraction operator +(Fraction a, int b)
        {
            Fraction c = new Fraction(a);
            c.setValue(c.Numerator + b*c.Denominator, c.Denominator);
            return c;
        }
        public static Fraction operator -(int a, Fraction b)
        {
            Fraction c = new Fraction(b);
            c.setValue(a * c.Denominator - c.Numerator, c.Denominator);
            return c;
        }
        public static bool operator ==(Fraction a,Fraction b)
        {
            if (a.Numerator == b.Numerator && a.Denominator == b.Denominator) return true;
            else return false;
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            if (a.Numerator == b.Numerator && a.Denominator == b.Denominator) return false;
            else return true;
        }
    }
}
