using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        private int _numer;
        private int _denom;
        private static int _count;

        public int Numer
        {
            get { return _numer; }
            set { _numer = value; }
        }
        public int Denom
        {
            get { return _denom; }
            set { _denom = (value != 0) ? value : 1; }
        }
        public static int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public Fraction()
        {
            _numer = 0;
            _denom = 1;
            Count++;
        }
        public Fraction (Fraction a)
        {
            Numer = a.Numer;
            Denom = a.Denom;
        }
        public Fraction (int numerator,int denominator)
        {
            Numer = numerator;
            Denom = denominator;
            Count++;
        }
        public Fraction(int a)
        {
            Numer = a;
            Denom = 1;
            Count++;
        }

        public Fraction setValue (int n,int d)
        {
            this.Numer = n;
            this.Denom = d;
            return this;
        }
        public static int GCD(int n, int d)
        {
            if (n == 0) return d;
            return GCD(d % n, n);
        }

        public bool Equals(Fraction a)
        {
            return (this.Numer / this.Denom == a.Numer / a.Denom);
        }
        public static Fraction operator +(Fraction n,Fraction d)
        {
            return new Fraction(n.Numer * d.Denom + n.Denom * d.Numer, n.Denom * d.Denom);
        }
        public static Fraction operator +(Fraction n,int d)
        {
            return new Fraction(n.Denom * d + n.Numer, n.Denom);
        }
        public static Fraction operator +(int n,Fraction d)
        {
            return new Fraction(n * d.Denom + d.Numer, d.Denom);
        }
        public static Fraction operator ++(Fraction n)
        {
            return new Fraction(n.Denom + n.Numer, n.Denom);
        }
        public static Fraction operator -(Fraction n,Fraction d)
        {
            return new Fraction(n.Numer * d.Denom - n.Denom * d.Numer, n.Denom * d.Denom);
        }
        public static Fraction operator -(Fraction n,int d)
        {
            return new Fraction(n.Numer - d * n.Denom, n.Denom);
        }
        public static Fraction operator -(int n,Fraction d)
        {
            return new Fraction(n * d.Denom - d.Numer, d.Denom);
        }
        public static bool operator ==(Fraction n,Fraction d)
        {
            return (n.Numer / n.Denom == d.Numer / d.Denom) ? true : false;
        }
        public static bool operator !=(Fraction n,Fraction d)
        {
            return (n.Numer / n.Denom != d.Numer / d.Denom) ? true : false;
        }
        public override string ToString()
        {
            return string.Format("[Rational: {0}/{1}], value={2}]", this.Numer / GCD(this.Numer, this.Denom), this.Denom / GCD(this.Numer, this.Denom), (double)this.Numer / (double)this.Denom);
        }
    }
}
