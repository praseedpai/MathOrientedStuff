using System;


class Test
{

  public static int Execute( Func<int, int, int > par )
  {
      int temp = 40;
      return par(10,10);

  }

  public static void Main( String [] args ) {

    int temp = 20;

    Func<int, int,int> fn =  (a,b) =>  a + b + temp; 

    Console.WriteLine( Test.Execute(fn));


  }




}