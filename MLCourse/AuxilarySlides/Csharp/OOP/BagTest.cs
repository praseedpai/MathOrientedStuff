///////////////////////////////////////////
//Bag.cs
//
// A program to prototype A container which 
// will behind the scenes use reflection to 
// return value associated with a property.
// Container will expose an Indexer to the 
// Outside world...
//
// Usage:-
//
// Bag<Person> bg = new Bag<Person>();
// bg["Name"] should return Value of name prop.
// 
// bg["Name"] = "New Name" // mutate name
//
// At the Visual studio command prompt
// -----------------------------------
// csc Bag.cs
// Bag.exe

using System;
using System.Reflection;


////////////////////////////////////////////////
// 
// Bag Utility class
//
//
//
public class Bag<T>
{
   ///////////////////////////
   // Stores the Objects
   //
   T _val ;

   //////////////////////////////////
   //
   // Constructor takes an Object Reference
   // as parameter
    
   public Bag( T par ) {
       _val = par;
   } 

   /////////////////////////////////////////
   //
   //  Indexer
   //
   public Object this[string s]
   {
        get
        {
                
            //---Call Helper method to 
            //---interact with Reflection
            //--- System
            return GetField(_val,s);
        }

        set {
              
            //---Call Helper method to 
            //---interact with Reflection
            //--- System to mutate value 
            SetField(_val,s,value);
        }
    }

   /////////////////////////////////
   //
   // Get Value from Field
   //  
   private Object GetField(T v , string s ) {
        Type t = v.GetType();
        FieldInfo p = t.GetField(s);
        return  p.GetValue(v);
   }

   ///////////////////////////////////
   // Set Value To Field
   //
   private void SetField(T v , string s , Object val ) {
        Type t = v.GetType();
        FieldInfo p = t.GetField(s);
        Type t2 = Nullable.GetUnderlyingType(p.FieldType) ?? p.FieldType;
        object safeValue =  Convert.ChangeType(val, t2);
        p.SetValue(v,safeValue);
   }


}


//////////////////////////////
//
// A Sample POCO  
//
//
//

public class Person {
  public string Name;
  public int    Age;
  public float  Salary;

  public Person( String pName,
                 int pAge,
                 float pSalary ) {

        Name = pName;
        Age = pAge;
        Salary = pSalary;
  }

}

///////////////////////////////////
//
// Yet Another Sample POCO
//
//
public class ContactGroup {

  public int id;
  public string desc;

  public ContactGroup(int pid , string pdesc) {

     id = pid;
     desc = pdesc;

  }
}

////////////////////////////////////////
//
// EntryPoint
//
//
public class BagTester {

   public static void Main(String [] args ) {

         ///////////////////////////////
         // Demonstrates Read
         //
         Bag<ContactGroup> b = new Bag<ContactGroup>(new ContactGroup(1,"Praseed" ) );
         Console.WriteLine( b["id"] + "   " + b["desc"] );


         //////////////////////////////////////////////////////
         // Demonstrates Write..
         //   
         Bag<Person> c = new Bag<Person>( new Person("Shalvin",35,10000));
         float np = (float) c["Salary"];
         //////////////////////
         // Give a 10% Rise in Consulting Fee...
         // 
         c["Salary"] = np*1.2;
                  
         ///////////////////////////////////
         // Spit it
         // 
         Console.WriteLine(c["Salary"]);          
   }

}