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
        private int _denominator;
        private static int _count;

        public int numerator
        {
            get { return _numerator; }
            set { _numerator = value; }
        }
        public int denominator
        {
            get { return _denominator; }
            set {
                if(value == 0 )
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
            get { return _count; }
        }

        public Fraction()
        {
            _numerator = 0;
            _denominator = 1;
            _count++;
        }
        public Fraction(int a)
        {
            _numerator = a;
            _denominator = 1;
            _count++;
        }
        public Fraction(Fraction a)
        {
            _numerator = a._numerator;
            _denominator = a._denominator;
            _count++;
        }
        public Fraction(int a,int b)
        {
            _numerator = a;
            _denominator = b;
            _count++;
        }

        public void setValue(int a,int b)
        {
            numerator = a;
            denominator = b;
        }

        public static Fraction operator +(Fraction v1,Fraction v2)
        {
            Fraction plus = new Fraction();
            plus.numerator = (v1.numerator * v2.denominator) + (v2.numerator * v1.denominator);
            plus.denominator = (v1.denominator * v2.denominator);
            return plus;
        }

        public static Fraction operator +(Fraction v1, int a)
        {
            Fraction plus = new Fraction();
            plus.numerator = (a * v1.denominator + v1.numerator);
            plus.denominator = v1.denominator;
            return plus;
        }

        public static Fraction operator -(Fraction v1, Fraction v2)
        {
            Fraction plus = new Fraction();
            plus.numerator = (v1.numerator * v2.denominator) - (v2.numerator * v1.denominator);
            plus.denominator = (v1.denominator * v2.denominator);
            return plus;
        }

        public static Fraction operator -(int a,Fraction v2)
        {
            Fraction plus = new Fraction();
            plus.numerator = (a * v2.denominator - v2.numerator);
            plus.denominator = v2.denominator;
            return plus;
        }

        public static Fraction operator *(Fraction v1, Fraction v2)
        {
            Fraction plus = new Fraction();
            plus.numerator = (v1.numerator *v2.numerator);
            plus.denominator = v1.denominator*v2.denominator;
            return plus;
        }
        public static Fraction operator ++(Fraction v1)
        {
            
            v1.numerator = v1.numerator + v1.denominator;
            return v1;
        }

        public static bool operator ==(Fraction v1,Fraction v2)
        {
            return (v1.numerator == v1.numerator && v1.denominator == v2.denominator);

        }
        public static bool operator !=(Fraction v1, Fraction v2)
        {
            return (v1.numerator != v1.numerator || v1.denominator != v2.denominator);
        }
        
        public bool Equals(Fraction v1)
        {
            return (v1.numerator == numerator && v1.denominator == denominator);
        }

        public static int GCD(int a, int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (a > b)
                return GCD(a % b, b);
            else
                return GCD(a, b % a);
        }

        public override string ToString()
        {
            float y = (float)this.numerator / (float)this.denominator;
            int x = GCD(this.numerator, this.denominator);
            string s = "[Rational: " + numerator/x + "/" + denominator/x + "], value = " + y;
            return s;
        }
    }

}
