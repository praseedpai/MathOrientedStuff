using System;
using System.Collections.Generic;

public class test
{

   public static void MisCapture() {
	List<Func<int>> actions =
                 new List<Func<int>>();

	int variable = 0;
	while (variable < 5)
	{
    		actions.Add(() => variable * 2);
    		++ variable;
	}

	foreach (var act in actions)
	{
   		 Console.WriteLine(act.Invoke());
	}

   }

    public static void CorrectCapture() {
	List<Func<int>> actions =
                 new List<Func<int>>();

	int variable = 0;
	while (variable < 5)
	{
                int temp = variable;
    		actions.Add(() => temp * 2);
    		++ variable;
	}

	foreach (var act in actions)
	{
   		 Console.WriteLine(act.Invoke());
	}

   }

   public static void Main( String [] args )
   {

         MisCapture();
         CorrectCapture();
   }



}