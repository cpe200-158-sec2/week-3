using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        private int _Numerator;
        private int _Denominator;
        private static int _Count;

        public int Numerator
        {
            get { return _Numerator; }
            set { _Numerator = value; }
        }
        public int Denominator
        {
            get { return _Denominator; }
            set
            {
                if(value >=1 ) { _Denominator = value; }
                else { _Denominator = 1; }
            }

        }
        public static int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }


        public Fraction()
        {
            Numerator = 0;
            Denominator = 1;
            Count++;
         
        }
        public Fraction(int numer)
        {
            Numerator = numer;
            Denominator = 1;
            Count++;
        }
        public Fraction (Fraction a)
        {
            Numerator = a.Numerator;
            Denominator = a.Denominator;
            Count++;
        }

        public Fraction (int numer,int denom)
        {
            setValue(numer, denom);
            Count++;
        }

        public void setValue (int a,int b)
        {
        
            Numerator = a/GCD(a,b);
            Denominator = b / GCD(a,b);
     
        }

        public static int GCD (int a, int b)
        {
            int gcd = 1;
            for (int i=1; i<=a && i<= b; i++)
            {
                if(a%i==0 && b%i==0)
                {
                    gcd = i;
                }
            }
            return gcd;
        }

        public static Fraction operator +(Fraction a,Fraction b)
        {
            int N = 0, M = 0;
            N = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            M = a.Denominator * b.Denominator;

            return  new Fraction(N / GCD(N, M), M / GCD(N, M));

        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            int N = 0, M = 0;
            N = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            M = a.Denominator * b.Denominator;

            return new Fraction(N / GCD(N, M), M / GCD(N, M));

        }
        public static Fraction operator ++(Fraction a)
        {
            int N = 0;
            a.Numerator = a.Numerator + a.Denominator;
            return a;

        }

        public static Fraction operator +(Fraction a, int b)
        {
            int N = 0, M = 0;
            N = a.Numerator  + b * a.Denominator;
            M = a.Denominator ;
            return new Fraction(N / GCD(N, M), M / GCD(N, M));
        }
        public static Fraction operator +(int a, Fraction b)
        {
            int N = 0, M = 0;
            N = b.Numerator + a * b.Denominator;
            M = b.Denominator;
            return new Fraction(N / GCD(N, M), M / GCD(N, M));
        }

        public static Fraction operator -(Fraction a, int b)
        {
            int N = 0, M = 0;
            N = a.Numerator - b * a.Denominator;
            M = a.Denominator;
            return new Fraction(N / GCD(N, M), M / GCD(N, M));
        }
        public static Fraction operator -(int a, Fraction b)
        {
            int N = 0, M = 0;
            N = a * b.Denominator - b.Numerator;
            M = b.Denominator;
            return new Fraction(N / GCD(N, M), M / GCD(N, M));
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            return (a.Numerator == b.Numerator && a.Denominator == b.Denominator);
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            return (a.Numerator != b.Numerator || a.Denominator != b.Denominator);
        }

        public  bool Equals (Fraction a)
        {
            return (a.Numerator == Numerator && a.Denominator == Denominator);
        }

        public override string ToString()
        {
            return string.Format("[Rational: {0}/{1}], value={2}]", Numerator, Denominator, (double)_Numerator/(double)_Denominator);
        }


    }
}
