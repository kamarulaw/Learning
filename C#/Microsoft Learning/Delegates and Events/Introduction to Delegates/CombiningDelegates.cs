using System;
using System.Diagnostics;

namespace Delegates
{
    /* This example demonstrates how to create multicast delegates.  A useful property of delegate objects is that multiple objects
     * can be assigned to one delegate instance by using the + operator.  The multicast delegate contains a list of the assigned delegates.
     * When the multicast delegate is called, it invokes the delegates in the list, in order.  Only delegates of the same type can be combined.
     * 
     * The - operator can be used to remove a component delegate from a multicast delegate.  
     */

    delegate void CustomDel(string s); 
    public class CombiningDelegates
    {
        static void Hello(string s)
        {
            Console.WriteLine($"  Hello, {s}");
        }

        static void Goodbye(string s)
        {
            Console.WriteLine($"  Goodbye, {s}");
        }

        static void Main()
        {
            // Declare instances of the custom delegate
            CustomDel hiDel, byeDel, multiDel, multiMinusHiDel;

            // In this example, you can omit the custom delegate if you want to and use Action<string> instead
            // Action<string> hiDel, byeDel, multiDel, multiMinusHiDel

            // Create the delegate object hiDel that references the method Hello. 
            hiDel = Hello;

            // Create the delegate object byeDel that references the method Goodbye
            byeDel = Goodbye;

            // The two delegates, hiDel and byeDel, are combined to form multiDel
            multiDel = hiDel + byeDel;

            // Remove hiDel from the multicast delegate, leaving byeDel, which calls only the method Goodbye
            multiMinusHiDel = multiDel - hiDel;

            Console.WriteLine("Invoking delegate hiDel: ");
            hiDel("A");
            Console.WriteLine("Invoking delegate byeDel: ");
            byeDel("B");
            Console.WriteLine("Invoking delegate multiDel: ");
            multiDel("C");
            Console.WriteLine("Invoking delegate multiMinusHiDel: ");
            multiMinusHiDel("D"); 
        }
    }
}
