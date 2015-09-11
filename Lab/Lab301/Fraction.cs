using System;

public class Fraction
{
    private int _Numer, _Denom;
    public static int Count = 0;

    //seting Value
    public int Numer {
        get{ return _Numer; }
        set{ _Numer = value; }
    }

    public int Denom {
        get { return _Denom; }
        set {
            if (value == 0) {
                value = 1;
            }
            _Denom = value; }
    }        

    //constructor
    public Fraction()
    {
        this.setValue(0, 1);
        Count += 1;
    }

    public Fraction(Fraction _a)
    {
        this.setValue(_a._Numer, _a._Denom);
        Count += 1;
    }

    public Fraction(int numerator, int dominator =1)
    {
        this.setValue(numerator, dominator);
        Count += 1;
    }

    //inside functions
    public void setValue(int _numer, int _denom) {
        int a = GCD(_numer, _denom);
        if (a == 0) a = 1;
        this.Denom = _denom/a;
        this.Numer = _numer/a;
    }

    static public int GCD(int _number, int _denom) {
        int Answer = 0 ;
        for (int i = _number; i > 0; i--)
        {
            if (_number % i == 0 && _denom % i == 0 ){
                Answer = i;
                break;
            }
        }
        return Answer;
    }   

    public float GetValue()
    {
        return ((float)this.Numer / (float)this.Denom);
    }

    //overloading goes here.
    public static Fraction operator + (Fraction _a, Fraction _b){
        int a_n = _a.Numer, a_d = _a.Denom, b_n = _b.Numer, b_d = _b.Denom;
        if (a_d != b_d)
        {
            a_d *= _b.Denom;
            a_n *= _b.Denom;
            b_d *= _a.Denom;
            b_n *= _a.Denom;
        }
        return new Fraction(a_n + b_n, b_d);
    }
    public static Fraction operator +(Fraction _a, int _b)
    {
        _b *= _a.Denom;
        return new Fraction(_a.Numer + _b, _a.Denom);

    }
    public static Fraction operator -(Fraction _a, Fraction _b)
    {
        int a_n = _a.Numer, a_d = _a.Denom, b_n = _b.Numer, b_d = _b.Denom;
        if (a_d != b_d)
        {
            a_d *= _b.Denom;
            a_n *= _b.Denom;
            b_d *= _a.Denom;
            b_n *= _a.Denom;
        }
        return new Fraction(a_n - b_n, b_d);

    }
    public static Fraction operator -(Fraction _a, int _b)
    {
        _b *= _a.Denom;
        return new Fraction(_a.Numer - _b, _a.Denom);

    }

    public static Fraction operator ++(Fraction _a)
    {
        Count -= 1;
        return new Fraction(_a.Numer + (_a.Denom), _a.Denom);
    }
    public static Fraction operator --(Fraction _a)
    {
        Count -= 1;
        return new Fraction(_a.Numer - (_a.Denom), _a.Denom);
    }
    //bool
    public static bool operator ==(Fraction _a, Fraction _b)
    {
        return (_a.Numer == _b.Numer) && (_a.Denom == _b.Denom);
    }

    public static bool operator !=(Fraction _a, Fraction _b)
    {
        return (_a.Numer != _b.Numer) && (_a.Denom != _b.Denom);
    }

    public bool Equals(Fraction _b)
    {
        return (this.Numer == _b.Numer) && (this.Denom == _b.Denom);
    }

    //extra funcs
    public static Fraction operator -(int _b, Fraction _a)
    {
        _b *= _a.Denom;
        return new Fraction(_b - _a.Numer, _a.Denom);

    }

    public override string ToString()
    {
        string output = "" ;
        int _GCD = GCD(this.Numer, this.Denom);
        output += "[Rational: " + this.Numer + " / " + this.Denom + "], value = " + (float)this.GetValue() + "]";
        return output;
    }
}
