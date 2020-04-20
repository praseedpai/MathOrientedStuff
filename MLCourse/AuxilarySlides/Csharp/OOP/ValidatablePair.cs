////////////////////////
//First.cs
//
//using Mono 
//----------
// dmcs First.cs
//
//
//

using System;
using System.Diagnostics.CodeAnalysis ;


////////////////////////////////
//
// a BasePair class
//
//
public class BasePair<K,V> {
  protected   K Key;
  protected   V Value;

}


////////////////////////////////////
//
// A Ordinary Pair class....
//
//
//
public class Pair<K,V> : BasePair<K,V> {


  ////////////////////////////
  // new is given to silence the 
  // compiler while complaining 
  // about shadowing..
  //
  public new K Key { 
      get {
           return base.Key;
      }
      set {
           base.Key = value;

      }

  }


  public new  V Value { 
      get {
           return base.Value;
      }
      set {
           base.Value = value;

      }

  }

 
}

/////////////////////////////////////////
//
// A pair class with Validation.....
//
// Takes a Generic Lambda as parameter...
//
public class ValidatedPair<K,V> : BasePair<K,V> {

  /////////////////////////////////////
  //
  // Validator Lambda , Depending on
  // Key/Value , we can pass different one
  //
  private Func<K,V,bool> Validator;

  public ValidatedPair( Func<K,V,bool> val ) {
         this.Validator = val;
  }

  public new K Key { 
      get {
           return base.Key;
      }
      set {

          if ( Validator(value,base.Value) )   
                base.Key = value;

      }

  }


  public new  V Value { 
      get {
           return base.Value;
      }
      set {

          if ( Validator(base.Key,value) )   
                base.Value = value;



      }

  }

 
}

////////////////////////////////////////
//
// A sample program to test the above
//
//
//

public class First {
  public static void Main(String [] args ) {

      Pair<int,string> pr = new Pair<int,string>();
      pr.Key = 100;
      pr.Value = "FFFFFF";

      Func<int,string,bool> valr =  ( a , b ) =>{ return  a > 0; } ;

      ValidatedPair<int , string> pr2 =
                 new  ValidatedPair<int , string>( valr); 

      pr2.Key = 10;
      pr2.Value = "ddd";

      //////////////////////////////
      // This assignment should fail...
      //
      pr2.Key = -100;
      
      ////////////////////////////////////
      // This should print 10
      //

      Console.WriteLine("Hello World..." + pr2.Key);  

  }
 
}

