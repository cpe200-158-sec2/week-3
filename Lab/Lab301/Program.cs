using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab202
{
    class Course
    {
        //Properties
        private string Name;
        private string CourseID;
        private string Lecturer;
        private int MaxStudents;
        private int NumStudents;

        public string _Name
        {
            get { return Name; }
            set { Name = value; }
        }

        public string _CourseID //CourseID (6-digit number only)            
        {
            get { return CourseID; }
            set
            {
                bool check = true;
                foreach (char idCourse in _CourseID)
                {
                    if (!Char.IsDigit(idCourse))
                        check = false;
                }
                if (value.Length != 6 || check == true) Console.WriteLine("{0}: error try setting invalid CourseID!", CourseID);
                else CourseID = value;
            }
        }

        public string _Lecturer
        {
            get { return _Lecturer; }
            set { Lecturer = value; }
        }

        public int _MaxStudents //MaxStudents(0-80, and >= NumStudents)
        {
            get { return MaxStudents; }
            set
            {
                if (value < NumStudents)
                    Console.WriteLine("{0}: error try setting invalid Max No. Students!", CourseID);
                else MaxStudents = value;
            }
        }

        public int _NumStudents //NumStudents(0-MaxStudents)
        {
            get { return NumStudents; }
            set
            {
                if (value > MaxStudents)
                    Console.WriteLine("{0}: error try setting invalid No. Students!", CourseID);
                else NumStudents = value;
            }
        }


        //Constructors
        //Course() : set default state
        public Course()
        {
            Name = "Unknow";
            CourseID = "Unknow";
            Lecturer = "staff";
            MaxStudents = 30;
        }
        //Course(Name, CourseID): takes 2 parameters
        public Course(string n, string cid)
        {
            Name = n;
            CourseID = cid;
            Lecturer = "Staff";
            MaxStudents = 30;
        }

        //Course(Name, CourseID, Lecturer): takes 3 parameters
        public Course(string n, string cid, string lec)
        {
            Name = n;
            CourseID = cid;
            Lecturer = lec;
            MaxStudents = 30;
        }
        //Course(Name, CourseID, Lecturer, MaxStudents): takes 4 parameters
        public Course(string n, string cid, string lec, int maxs)
        {
            Name = n;
            CourseID = cid;
            Lecturer = lec;
            MaxStudents = maxs;
        }

        //Methods
        //ToString(): display object state in specify format (see expected output)
        public override string ToString()
        {
            //[Course: Object-Oriented Programming (261300), Lecturer=staff, has 0 students, max=30]
            return string.Format("[Course: {0} ({1}), Lecturer={2}, has {3} students, max={4}]", Name, CourseID, Lecturer, NumStudents, MaxStudents);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        //Properties

        //Numer: Numerator
        private int _Numer;
        //Denom: Denominator(default=1, cannot be 0)
        private int _Denom;
        //Count: counting #objects of this class (static)
        public static int Count = 0;

        public int Numer
        {
            get { return _Numer; }
            set { _Numer = value; }
        }

        public int Denom
        {
            get { return _Denom; }
            set
            {
                if (value == 0)
                    _Denom = 1;
                else _Denom = value;
            }
        }


        //Constructors

        //Fraction() : default constructor
        public Fraction()
        {
            _Numer = 0;
            _Denom = 1;
            Count++;
        }
        public Fraction(int numerator)
        {
            _Numer = numerator;
            _Denom = 1;
            Count++;
        }
        //Fraction(Fraction a) : copy constructor
        public Fraction(Fraction a)
        {
            _Numer = a.Numer;
            _Denom = a.Denom;
            Count++;

        }
        //Fraction(numerator, denominator)
        public Fraction(int numerator, int denominator)
        {
            _Numer = numerator;
            _Denom = denominator;
            Count++;
        }

        //Methods

        //setValue: set fraction value
        public void setValue(int numerator, int denominator)
        {
            _Numer = numerator;
            if (denominator == 0)
                _Denom = 1;
            else
                _Denom = denominator;

        }
        //GCD: calculate Greatest Common Divisor of two integers(static)
        public static int GCD(int a, int b)
        {
            if (a == 0) return b;
            return GCD(b % a, a);
        }
        public bool Equals(Fraction f1)
        {
            return (f1.Numer == Numer && f1.Denom == Denom);
        }

        //[Rational: 0/1], value=0]
        public override string ToString()
        {
            return string.Format("[Rational: {0}/{1}], value={2}]", _Numer / GCD(_Numer, _Denom), _Denom / GCD(_Numer, _Denom), (double)_Numer / _Denom);
        }

        //overloading
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numer * f2.Denom + f2.Numer * f1.Denom, f1.Denom * f2.Denom);
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numer * f2.Denom - f2.Numer * f1.Denom, f1.Denom * f2.Denom);
        }
        public static Fraction operator ++(Fraction f)
        {
            f.Numer = f.Numer + f.Denom;

            return f;
        }
        public static Fraction operator -(int i, Fraction f)
        {
            return new Fraction(i * f.Denom - f.Numer, f.Denom);
        }
        public static Fraction operator +(Fraction f, int i)
        {
            return new Fraction(f.Numer + i * f.Denom, f.Denom);
        }
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return (f1.Numer == f2.Numer && f1.Denom == f2.Denom);
        }
        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return (f1.Numer != f2.Numer || f1.Denom != f2.Denom);
        }

    }
}