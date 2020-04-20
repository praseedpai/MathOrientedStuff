using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapReduce
{
    static class  Program
    {

	public static int AddOperation (int x, int y)
	{
		return x + y;
	}


	public static Func<T1, Func<T2, TReturn>> 
                Curry<T1, T2, TReturn>(Func<T1, T2, TReturn> f)
	{
		return a => b => f(a, b);
	}

        public static Func<T1, Func<T2, TReturn>> 
		Curry2<T1, T2, TReturn>(this Func<T1, T2,
			 TReturn> f)
	{
		return a => b => f(a, b);
	}

	public static string ConcatOperation (string x, string y)
	{
		return x + y;
	}

        public static Func<T1, Func<T2, 
		Func<T3, TReturn>>>Curry3<T1, T2, T3, TReturn>
	(this Func<T1, T2, T3, TReturn> f)
	{
		return a => b => c => f(a, b, c);
	}
	// Currying Extension Method that Supports 4 Input Parameters
	public static Func<T1, Func<T2, Func<T3, Func<T4, TReturn>>>>
		Curry4<T1, T2, T3, T4, TReturn>(this Func<T1, T2, T3, T4, TReturn> f)
	{
		return a => b => c => d => f(a, b, c, d);
	}


	//The formula that confirms a Pythagorean Triplet
	public static bool IsPythagoreanTriplet (int x, int y, int z)
	{
		return (x * x + y * y) == (z * z);
	}

        public static Func<T2, T3, TReturn>PartialApply<T1, T2, T3, TReturn>(this Func<T1, T2, T3, TReturn> f, T1 arg1)
	{
		return (arg2, arg3) => f(arg1, arg2, arg3);

        }
			//Partial Application in functions that have 4 Input Parameters
	public static Func<T2, T3, T4, TReturn>  PartialApply<T1, T2, T3, T4, TReturn>(this Func<T1, T2, T3, T4, TReturn> f, T1 arg1)
	{
		return (arg2, arg3, arg4) => f(arg1, arg2, arg3, arg4);
	}
	//Function that generates the triples within a given range based
	//on the above formula.
	public static IEnumerable<IEnumerable<int>>
		PythagoreanTriples (int range)
	{
		Func<int, int, int, bool> formula = IsPythagoreanTriplet;
		HashSet<string> capturedTriplets = new HashSet<string>();
		for (int a = 1; a < range; a++)
		{
			for (int b = 1; b < range; b++)
			{
				for (int c = 1; c < range; c++)
				{
					if (formula(a, b, c)) //Direct Evaluation
					{
						string keyPart1 = a.ToString();
						string keyPart2 = b.ToString();
						//This check filters the duplicate triplets
						if (!capturedTriplets.Contains(keyPart1 + ":" + keyPart2)
						&&!capturedTriplets
							.Contains(keyPart2 + ":" + keyPart1))
						{
							capturedTriplets
								.Add(keyPart1 + ":" + keyPart2);
							yield return new List<int>() { a, b, c };
						}
					}
				}
			}
		}
	}



	public static IEnumerable<IEnumerable<int>>PythagoreanTriplesCurried (int range)
	{
		Func<int, int, int, bool> formula = IsPythagoreanTriplet;
		var cFormula = formula.Curry3<int, int, int, bool>();
		HashSet<string> capturedTriplets = new HashSet<string>();
		for (int a = 1; a < range; a++)

		{
			for (int b = 1; b < range; b++)
			{
				for (int c = 1; c < range; c++)
				{
					if (cFormula(a)(b)(c)) //Curried Evaluation
					{
						string keyPart1 = a.ToString();
						string keyPart2 = b.ToString();
						//This check filters the duplicate triplets
						if (!capturedTriplets.Contains(keyPart1 + ":" + keyPart2)
						&&!capturedTriplets
							.Contains(keyPart2 + ":" + keyPart1))
						{
							capturedTriplets
								.Add(keyPart1 + ":" + keyPart2);
							yield return new List<int>() { a, b, c };
						}
					}
				}
			}
		}
	}


        public static IEnumerable<IEnumerable<int>>PythagoreanTriplesPartiallyApplied (int range)
	{
		Func<int, int, int, bool> formula = IsPythagoreanTriplet;
		HashSet<string> capturedTriplets = new HashSet<string>();
		for (int a = 1; a < range; a++)
		{
			var paFormula = formula.PartialApply<int, int, int, bool>(a);
			for (int b = 1; b < range; b++)
			{
				for (int c = 1; c < range; c++)
				{
					//Final Evaluation with remaining arguments
					if (paFormula(b, c))
					{
						string keyPart1 = a.ToString();
						string keyPart2 = b.ToString();
						//This check filters the duplicate triplets
						if (!capturedTriplets.Contains(keyPart1 + ":" + keyPart2)
						&&!capturedTriplets
							.Contains(keyPart2 + ":" + keyPart1))
						{
							capturedTriplets
								.Add(keyPart1 + ":" + keyPart2);
							yield return new List<int>() { a, b, c };
						}
					}
						
					
				}
			}
		}
	}
        
        static void Main(string[] args)
        {
            var curriedSum = 
               Curry<int, int, int>(AddOperation);
		Console.WriteLine( "Sum: {0}", curriedSum(10)(90));
		
            Func<int, int, int> op = AddOperation;
		var curriedSum1 = op.Curry2<int, int, int>();
		Console.WriteLine("Sum: {0}",curriedSum1(10)(90));
	    //Prints Sum: 100

            Func<string, string, string> op2 = ConcatOperation;
		var curriedConcat = op2.Curry2<string, string, string>();
		Console.WriteLine("Concatenation: {0}",curriedConcat("Currying ")("Rocks!!!"));


		Console.WriteLine("PythagoreanTriples within 50....");
		foreach (var triplets in PythagoreanTriplesPartiallyApplied(50))
		{
			Console.WriteLine(string.Join(",", triplets.ToArray()));
		}
		Console.ReadLine();

        }
    }
}
