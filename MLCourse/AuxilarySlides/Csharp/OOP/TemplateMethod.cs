//////////////////////
//
// TemplateMethod.cs
//  
// Written by Praseed Pai K.t.
//            http://praseedp.blogspot.com
//
//
// gmcs TemplateMethod.cs -r:System.dll
// mono TemplateMethod.exe
//

using System;

////////////////////////////////
//
// Declare a Logger class ...with one abstract method
// DoLog
// 
// DoLog is our template method...
//
public abstract class Logger {

      /////////////////////////////
      //
      // Concrete classes will override this 
      protected abstract bool DoLog( String logitem );

      ///////////////////////////////////////////
      //
      // public API  
      public bool Log( String app , String key , String cause ) {
             return DoLog( app + " " + key + " " + cause );
      }

}

//////////////////////////////////////
//
// DbLogger will log to the Database...!
//
// This will override the template method !

public class DbLogger : Logger
{
    protected override bool DoLog( String logitem ) {
           // Log into the DB
           Console.WriteLine( "DB Log " + logitem );  
           return true;
    }


}
//////////////////////////////////////////////
// FileLogger will log into the Disk File...
//
//  
//
public class FileLogger : Logger
{
    protected override bool DoLog( String logitem ) {
           // Log into the File
           Console.WriteLine( "File Log " + logitem );
           return true;   
    }


}
/////////////////////////////
//
// NullLogger is a NOP logger....
//
public class NullLogger : Logger
{
    protected override bool DoLog( String logitem ) {
           // Log into the File
           Console.WriteLine( "Ignoring the log...!" );
           return true;   
    }


}

//////////////////////////////////////////
//
// Create a Factory method to instantiate the Logger....!
//
// LoggerFactory can be singleton...
//
public class LoggerFactory {
     public static Logger CreateLogger( string loggertype ) {

               if ( loggertype == "DB" )
                      return new DbLogger();
               else if ( loggertype == "FILE" )
                      return new FileLogger();
               else
                      return new NullLogger();
                
     }

}

//////////////////////////////////////////////
//
// EntryPoint ...!
//
//
public class Caller
{
   public static void Main( String[] s ) {
     Logger l = LoggerFactory.CreateLogger("FILE");
     l.Log("MyApp" , "SEVERITY" ,"NOTHIN SERIOUS");
     l = LoggerFactory.CreateLogger("DB");
     l.Log("MyApp" , "SEVERITY TO DB " ,"NOTHIN SERIOUS");

          
   }


}