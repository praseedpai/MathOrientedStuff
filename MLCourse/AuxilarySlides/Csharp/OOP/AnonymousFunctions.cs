using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic; 

public class Counter
{
        public static int AddOperation (int x, int y)
	{
		return x + y;
	}

	Func<int, int, int> AddOperation2 = 
		delegate(int x, int y) {
			return x + y;
	};

	public static Func<int, Func<int, int>> sum =
		x => y => x + y;
	


	public static void Main(String [] args ) {

		/* Func<int, int, int> AddOperation = 
		delegate(int x, int y) {
			return x + y;
		}; */

		/*Func<int, int, int> AddOperation =
			 (x, y) => x + y;*/

		Func<string, string, string> 
				ConcatOperation = 
    			(x, y) => x + y;

                var add10 = sum(10); //Returns closure with 10
		var add50 = sum(50); //Returns closure with 50
		Console.WriteLine(add10(90)); //Returns 100
		Console.WriteLine(add10(190)); //Returns 200
		Console.WriteLine(add50(70)); //Returns 120

        }
}