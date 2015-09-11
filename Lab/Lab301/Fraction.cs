using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    public class Fraction
    {
        
        //Private Object
        private int _Numer;
        private int _Denom;
        private static int _Count;

        //Public Object
        public int Numer { get; set; }
        public int Denom
        {

            get { return _Denom; }
            set { _Denom = (value != 0) ? value : 1; }

        }
        public static int Count { get; set; }

        //Constructors
        public Fraction()
        {

            Numer = 0;
            Denom = 1;
            Count++;

        }
        public Fraction(Fraction i)
        {

            Numer = i.Numer;
            Denom = i.Denom;
            Count++;

        }
        public Fraction(int i, int j)
        {

            Numer = i;
            Denom = j;
            Count++;

        }
        public Fraction(int i)
        {

            Numer = i;
            Denom = 1;
            Count++;

        }

        //Methods
        public Fraction setValue(int i, int j)
        {

            this.Numer = i;
            this.Denom = j;
            return this;

        }
        public static int GCD(int a, int b)
        {

            return b != 0 ? GCD(b, a % b) : a;

        }
        public bool Equals(Fraction i)
        {

            return (this.Numer / this.Denom == i.Numer / i.Denom);

        }

        //Operator Overloading
        public static Fraction operator +(Fraction i, Fraction j)
        {

            return new Fraction((i.Numer * j.Denom) + (j.Numer * i.Denom), (i.Denom * j.Denom));

        }
        public static Fraction operator -(Fraction i, Fraction j)
        {

            return new Fraction((i.Numer * j.Denom) - (j.Numer * i.Denom), (i.Denom * j.Denom));

        }
        public static Fraction operator ++(Fraction i)
        {

            return new Fraction(i.Numer + i.Denom, i.Denom);

        }
        public static Fraction operator +(Fraction i, int j)
        {

            return new Fraction(i.Numer + (j * i.Denom), i.Denom);

        }
        public static Fraction operator -(Fraction i, int j)
        {

            return new Fraction(i.Numer - (j * i.Denom), i.Denom);

        }
        public static Fraction operator +(int i, Fraction j)
        {

            return new Fraction((i * j.Denom) + j.Numer, j.Denom);

        }
        public static Fraction operator -(int i, Fraction j)
        {

            return new Fraction((i * j.Denom) - j.Numer, j.Denom);

        }
        public static bool operator ==(Fraction i, Fraction j)
        {

            return ((i.Numer / i.Denom) == (j.Numer / j.Denom));

        }
        public static bool operator !=(Fraction i, Fraction j)
        {

            return ((i.Numer / i.Denom) != (j.Numer / j.Denom));

        }
        public override string ToString()
        {

            return string.Format("[Rational: {0}/{1}], value={2}]", this.Numer / GCD(this.Numer, this.Denom), this.Denom / GCD(this.Numer, this.Denom), (double)this.Numer / (double)this.Denom);

        }
    }
}