using System;

namespace Lab301
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Fraction r1 = new Fraction();
			Fraction r2 = new Fraction(2);
			Fraction r3 = new Fraction(3,9);

			Console.WriteLine ("***** " + Fraction.Count + " Fraction objects have been created *****");

			Fraction r4 = r1+r2;
			Fraction r5 = r2-r3;
			Fraction r6 = new Fraction(100,50);
			r6 += r2;

			Fraction r7 = new Fraction(r3);		// case#1
//			Fraction r7 = r3;					// case#2
			r7++;

			Console.WriteLine ("***** " + Fraction.Count + " Fraction objects have been created *****");

			Fraction r8 = 10 - (new Fraction(80,40));
			Fraction r9 = (new Fraction(5,25)) + 1;

			Console.WriteLine ("***** " + Fraction.Count + " Fraction objects have been created *****");

			Console.WriteLine (r1);
			Console.WriteLine (r2);
			Console.WriteLine (r3);
			Console.WriteLine (r4);
			Console.WriteLine (r5);
			Console.WriteLine (r6);
			Console.WriteLine (r7);
			Console.WriteLine (r8);
			Console.WriteLine (r9);

			Console.WriteLine (r2==r4);
			Console.WriteLine (r4.Equals (r2)); // Equals method must be overriden
			Console.WriteLine (r2!=r4);

			r3.setValue (10,12/3*0);
			Console.WriteLine (r3);

			Console.WriteLine ("***** " + Fraction.Count + " Fraction objects have been created *****");

			Console.WriteLine("GCD of 3650 and 360: " + Fraction.GCD (3650,360));
			Console.WriteLine("GCD of 3600 and 360: " + Fraction.GCD (3600,360));
            Console.ReadKey();

		}
	}
}
