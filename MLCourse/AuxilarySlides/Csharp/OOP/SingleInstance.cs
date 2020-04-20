///////////////////////////////////
// SingleTonExample.cs
//
// Written by Praseed Pai K.T. 
//            http://praseedp.blogspot.com
//
// gmcs SingleTonExample.cs -r:System.dll
// mono SingleTonExample.exe
//
//

using System;

public sealed class SingleInstanceClass
{
    ////////////////
    // Only instance variable ...!
    //
    int _value;
       
    private static SingleInstanceClass _inst = null;
    /////////////////////////
    //
    // Hide the Constructor ....!
    private SingleInstanceClass() { _value = 0; }

    
    ///////////////////////////////////
    //
    // Get the Instance ...!
    //
    public static SingleInstanceClass GetInstance() {
            if ( _inst == null )
                 _inst = new SingleInstanceClass();

            return _inst;   
    }     

    //////////////////////////////////////
    //
    //  a Property for the instance variable...
    //
    public int Value {
           get { return _value; }
           set { _value = value; }
    }
}
////////////////////////////
//
// The Caller.....!
//
//

public class Caller
{
     public static void Main(String [] args ) {

                SingleInstanceClass p = SingleInstanceClass.GetInstance();
                p.Value = 10; 
                SingleInstanceClass q = SingleInstanceClass.GetInstance();
                q.Value = 20;
                /////////////////////////
                //
                // p and q should hold the same value ...! 
                Console.WriteLine( q.Value );
                Console.WriteLine( p.Value ); 
     }       


}