/*
 * Created by SharpDevelop.
 * User: Recurring
 * Date: 9/17/2015
 * Time: 8:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;


namespace Lab301
{
	class Fraction
    {
        int num;
        int dnom = 1;
        static int count = 0;
       
        public int Numerator{
            get { return num; }
            set { num = value; }
        }
        
        public int Denominator{
            get { return dnom; }
            set { dnom = value; }
        }
        
        public static int Count{
            get { return count; }
        }
        
        public Fraction(){ //basic form
            num = 0;
            dnom = 1;
            count++;
        }
        
        public Fraction(Fraction a){
            setValue(a.num, a.dnom);
            count++;
        }
        
        public Fraction(int num,int dnom = 1){ //base denom=1
            setValue(num, dnom);
            count++;
        }
        
        public void setValue(int numer, int denom){
            num = numer;
            if (denom > 0)
                dnom = denom;
            else dnom = 1;
            makeLeastNumer();
        }

        void makeLeastNumer(){
            int a;
            a=GCD(num,dnom);
            num/=a;
            dnom/=a;
        }
        
        static public int LCM(int a,int b) {
            int c,d;
            if (a>b){ 
            	c=a; d=b;
            }	
            else{
            	c=b; d=a;
            }
            for (int i = 1; i <= d; i++){
                if ((c*i) % d == 0){
                    return i * c;
                }
            }
            return d;
        }
        
        static public int GCD(int a, int b){
            while (a!=b){
        		if (a>b){
        			a-=b;
        		}
        		else{
        			b-=a;
        		}
            }
            return a;
        }
       
        public override string ToString(){
            return "[Rational: " + Numerator + " / " + Denominator + "], value = " + Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator) + "]";
        }
        
        public override bool Equals(Object a){
            Fraction c = (Fraction)a;
            if (c.Numerator == Numerator && c.Denominator == Denominator){
            	return true;
            }
            else{
            	return false;
            }
        }

        public static Fraction operator+ (Fraction a,Fraction b){
            Fraction c = new Fraction();
            int lcm = LCM(a.Denominator, b.Denominator);
            c.setValue(a.Numerator * (lcm / a.Denominator) + b.Numerator * (lcm / b.Denominator), lcm);
            return c;
        }
        
        public static Fraction operator -(Fraction a,Fraction b) {
            Fraction c = new Fraction();
            int lcm = LCM(a.Denominator, b.Denominator);
            c.setValue(a.Numerator * (lcm / a.Denominator) - b.Numerator * (lcm / b.Denominator), lcm);
            return c;
        }
        
        public static Fraction operator++(Fraction a){
            a.setValue(a.Numerator + a.Denominator, a.Denominator);
            return a;
        }
        
        public static Fraction operator +(Fraction a,int b){
            Fraction c = new Fraction(a);
            c.setValue(c.Numerator + b*c.Denominator, c.Denominator);
            return c;
        }
        
        public static Fraction operator +(int b,Fraction a){
            Fraction c = new Fraction(a);
            c.setValue(c.Numerator + b*c.Denominator, c.Denominator);
            return c;
        }
        
        public static Fraction operator -(int a, Fraction b){
            Fraction c = new Fraction(b);
            c.setValue(a * c.Denominator - c.Numerator, c.Denominator);
            return c;
        }
        
        public static Fraction operator -(Fraction a,int b){
            Fraction c = new Fraction(b);
            c.setValue(c.Numerator - (b*c.Denominator), c.Denominator);
            return c;
        }
        
        public static bool operator ==(Fraction a,Fraction b){
        	if (a.Numerator == b.Numerator && a.Denominator == b.Denominator){
        		return true;
        	}
        	else{
        		return false;
        	}
        }
        
        public static bool operator !=(Fraction a, Fraction b){
        	if (a.Numerator == b.Numerator && a.Denominator == b.Denominator){
        		return false;
        	}
        	else{
        		return true;
        	}
        }
        
        public override int GetHashCode(){ //put to prevent error from ==,!=
   			return 0;
    	}
	}
