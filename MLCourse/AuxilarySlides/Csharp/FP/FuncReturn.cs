using System;
using System.Collections.Generic;

public class test
{

  
   public static Func<int,int> Add( int a , int b ) {
      int x = ( a + b ) >> 1;

      return (int  y ) => {

         return x + y;
      };

   }

   public static void Main( String [] args )
   {

        Func<int,int> s = Add(50,40);

        Console.WriteLine( s(20));
   }



}