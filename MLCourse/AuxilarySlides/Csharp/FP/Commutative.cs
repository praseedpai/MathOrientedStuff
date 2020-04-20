using System;
using System.Threading;


class Test {

  static volatile int a=20;
  static volatile int b=30;

  public static void thread_func() {

    while (true ) {
      Random rnd = new Random();
      int month = rnd.Next(1, 13); // creates a number between 1 and 12
     

      if ( month %2 == 0  ) {
              a = rnd.Next(1, 13);
               Console.Write(".");
      }
      else if ( month%2 == 1) {
              b = rnd.Next(1, 13);
               Console.Write("#");

      }

      Thread.Sleep(100);

     }


  }


  public static void Main(String [] args )
  {
      int x = 0;

      ThreadStart childref = new ThreadStart(thread_func);
       

      Thread th = new Thread(childref);
      th.Start();

       Thread.Sleep(1000);
      while ( true ) {

      
           var c = a + b;
           Thread.Sleep(90);
           var  d = b + a;

            if ( c != d )

            Console.Out.WriteLine("Commutative Property Violated");
       


        if ( ++x == 10000 )
             break;
      }

  }

}