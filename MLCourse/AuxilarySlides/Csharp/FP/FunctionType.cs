using System;
using System.Collections.Generic;

public class FunctionType
{

   public static IEnumerable<T> GenerateSequences<T> (
		int noOfElements, Func<T> generator)
	{
		for ( int i = 0; i < noOfElements; i++ )
		{
			yield return generator();
		}
	}

       public static IEnumerable<TSource> 
		Where<TSource> (IEnumerable<TSource> source,
                Predicate<TSource> predicate)
	{
		foreach ( TSource element in source )
		{
			if ( predicate(element) )
				yield return element;
		}
	}
  
  

   public static void Main( String [] args )
   {

        int startEven = -2;
	int startOdd = -1;
	int increment = 2;
	//To Generate first 1000 even numbers
	IEnumerable<int> evenSequences = 
		GenerateSequences<int> (
			1000, () => startEven += increment);
	//To Generate first 1000 odd numbers
		IEnumerable<int> oddSequences =
		 GenerateSequences<int> (
			1000, () => startOdd += increment);
   }



}