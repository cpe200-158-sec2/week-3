using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    public class Fraction
    {
        private int Numer;
        private int Denom;
        private static int _Count;

        public int numer { get; set; }
        public int decom
        {
            get { return Denom; }
            set { Denom = (value != 0) ? value : 1; }
        }

        public static int Count { get; set; }

        public Fraction()
        {
            numer = 0;
            decom = 1;
            Count++;
        }

        public Fraction(Fraction i)
        {
            numer = i.numer;
            decom = i.decom;
            Count++;
        }

        public Fraction(int i, int j)
        {
            numer = i;
            decom = j;
            Count++;
        }

        public Fraction(int i)
        {
            numer = i;
            decom = 1;
            Count++;
        }

        public Fraction setValue(int i, int j)
        {
            this.numer = i;
            this.decom = j;

            return this;
        }

        public static int GCD(int a, int b)
        {
            return b != 0 ? GCD(b, a % b) : a;
        }

        public bool Equals(Fraction i)
        {
            return (this.numer / this.decom == i.numer / i.decom);
        }

        public static Fraction operator +(Fraction i, Fraction j)
        {
            return new Fraction((i.numer * j.decom) + (j.numer * i.decom), (i.decom * j.decom));
        }

        public static Fraction operator -(Fraction i, Fraction j)
        {
            return new Fraction((i.numer * j.decom) - (j.numer * i.decom), (i.decom * j.decom));
        }

        public static Fraction operator ++(Fraction i)
        {
            return new Fraction(i.numer + i.decom, i.decom);
        }

        public static Fraction operator +(Fraction i, int j)
        {
            return new Fraction(i.numer + (j * i.decom), i.decom);
        }

        public static Fraction operator -(Fraction i, int j)
        {
            return new Fraction(i.numer - (j * i.decom), i.decom);
        }

        public static Fraction operator +(int i, Fraction j)
        {
            return new Fraction((i * j.decom) + j.numer, j.decom);
        }

        public static Fraction operator -(int i, Fraction j)
        {
            return new Fraction((i * j.decom) - j.numer, j.decom);
        }

        public static bool operator ==(Fraction i, Fraction j)
        {
            return ((i.numer / i.decom) == (j.numer / j.decom));
        }

        public static bool operator !=(Fraction i, Fraction j)
        {
            return ((i.numer / i.decom) != (j.numer / j.decom));
        }

        public override string ToString()
        {
            return string.Format("[Rational: {0}/{1}], value={2}]", this.numer / GCD(this.numer, this.decom), this.decom / GCD(this.numer, this.decom), (double)this.numer / (double)this.decom);
        }
    }
}