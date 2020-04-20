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
		Func<T3, TReturn>>>Curry<T1, T2, T3, TReturn>
	(this Func<T1, T2, T3, TReturn> f)
	{
		return a => b => c => f(a, b, c);
	}
	// Currying Extension Method that Supports 4 Input Parameters
	public static Func<T1, Func<T2, Func<T3, Func<T4, TReturn>>>>
		Curry<T1, T2, T3, T4, TReturn>(this Func<T1, T2, T3, T4, TReturn> f)
	{
		return a => b => c => d => f(a, b, c, d);
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
//Prints "Concatenation: Currying Rocks!!!"

        }
    }
}
