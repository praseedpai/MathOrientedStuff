using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic; 

public class Counter
{
	private int i = 0;
	public int AddOneRO (int x) //Referentially Opaque
	{
		i += 1;
		return x + i;
	}
	public int AddOneRT (int x) //Referentially Transparent
	{
		return x + 1;
	}


	public static void Main(String [] args ) {
		// Now since AddOneRO (x) <> AddOneRO (y)  
                // if x = y, this further
                // implies AddOneRO (x) - AddOneRO (x) <> 0,
                // thus invalidating the fundamental 
                // mathematical identity (x - x = 0)!

        }
}