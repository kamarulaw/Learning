using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class DelegatesWIthNamedVsAnonymousMethods1_Intro
    {
        /* A delegate can be associated with a named method.  When you instantiate a delegate by using a named method, the method is passed as 
         * a parameter, for example: 
         */

        // Declare a delegate
        delegate void Del(int x); 
        // Define a named method
        void DoWork(int k) {/*...*/}
        // Instantiate the delegate using the method as a parameter
        Del d = new DelegatesWIthNamedVsAnonymousMethods1_Intro().DoWork;

        /* This is called using a named method.  Delegates constructed with a named method can encapsulate either a static method or an instance method.
         * Named methods are the only way to instantiate a delegate in earlier versions of C#.  However, in a situation where creating a new method is 
         * unwanted overhead, C# enables you to instantiate a delegate in earlier versions of C#.  However, in a situation where creating a new method 
         * is unwanted overhead, C# enables you to instantiate a delegate and immediatley specify a code block that the delegate will process when it is 
         * called.  The block can contain either a lambda expression or an anonymous method. 
         * 
         * The method that you pass as a delegate parameter must have the same signature as the delegate declaration.  A delegate instance may 
         * encapsulate either static or instance method.  Beginning with C# 10, method groups with a single overload have a natural type.  This 
         * means the compiler can infer the return type and parameter types for the delegate type.  
         */
        public static void Main(string[] args)
        {
            var read = Console.Read; // Just one overload; Func<int> inferred
            var write = Console.Write; // ERROR: Mulitple overloads, can't choose
        }
    }
}
