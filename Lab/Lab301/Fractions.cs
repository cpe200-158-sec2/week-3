using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        private static int _count = 0;
        private int _n, _d;
        public static int Count
        {
            get { return _count; }
        }
        public static int GCD(int x, int y)
        {
            int remain;
            while (y != 0)
            {
                remain = x % y;
                x = y;
                y = remain;
            }
            return x;
        }
        public int numer
        {
            get { return _n; }
            set { _n = value; }
        }
        public int denom
        {
            get { return _d; }
            set { _d = value; }
        }
        public Fraction()
        {
            _count++;
            numer = 0;
            denom = 1;
        }
        public Fraction(int a)
        {
            _count++;
            numer = a;
            denom = 1;
        }
        public Fraction(int a, int b)
        {
            _count++;
            setValue(a, b);
        }
        public Fraction(Fraction r)
        {
            _count++;
            this.numer = r.numer;
            this.denom = r.denom;
        }
        public void setValue(int x, int y)
        {
            if (y == 0)
            {
                y = 1;
            }
            numer = x / GCD(x, y);
            denom = y / GCD(x, y);
        }

        public static Fraction operator+(Fraction i,Fraction j)
        {
            int numerator = 0,denominator = 0;
            if (i.denom == j.denom)
            {
                numerator = i.numer + j.numer;
                denominator = i.denom;
            }
            if (i.denom != j.denom)
            {
                numerator = i.numer * j.denom + j.numer * i.denom;
                denominator = i.denom * j.denom;
            }
            return new Fraction(numerator, denominator);
        }
        public static Fraction operator -(Fraction i, Fraction j)
        {
            int numerator=0,denominator=0;
            if (i.denom == j.denom)
            {
                numerator = i.numer - j.numer;
                denominator = i.denom;
            }
            if (i.denom != j.denom)
            {
                numerator = i.numer * j.denom - j.numer * i.denom;
                denominator = i.denom * j.denom;
            }
                return new Fraction(numerator, denominator);
        }
        public static Fraction operator ++(Fraction i)
        {
            i.numer += i.denom;
            return i;
        }
        public static Fraction operator -(int a,Fraction i)
        {
            return new Fraction(a*i.denom - i.numer,i.denom);
        }
        public static Fraction operator +(Fraction i,int a)
        {
            return new Fraction(i.numer+a*i.denom,i.denom);
        }
        public static bool operator==(Fraction i,Fraction j)
        {
            bool express=false;
            if(i.numer==j.numer && i.denom == j.denom)
            {
                express = true;
            }
            return express;
        }
        public static bool operator !=(Fraction i, Fraction j)
        {
            bool express = true;
            if (i.numer == j.numer && i.denom == j.denom)
            {
                express = false;
            }
            return express;
        }
        public bool Equals(Fraction i)
        {
            bool express=false;
            if (this.numer == i.numer && this.denom == i.denom)
            {
                express = true;
            }
            return express;
        }
        public override string ToString()
        {
            double val = (double)this.numer / (double)this.denom;
            string l = "[Rational: " + this.numer + "/" + this.denom + "], value=" + val;
            return l;
        }
    }
}

