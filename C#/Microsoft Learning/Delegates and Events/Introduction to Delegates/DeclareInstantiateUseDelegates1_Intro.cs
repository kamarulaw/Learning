using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class DeclareInstantiateUseDelegates1_Intro
    {
        /* You can declare delegates using any of the following methods */

        // (1) Declare a delegate type and declare a method with a matching signature
        
        // (1.1) Declare a delegate
        delegate void Del(string str); 

        // (1.2) Declare a method with the same signature as the delegate
        static void Notify(string name)
        {
            Console.WriteLine($"Notification received for: {name}");
        }

        // (1.3) Create an instance of the delegate
        Del del1 = new Del(Notify);

        // (2) Assign a method group to a delegate type
        Del del2 = Notify;

        // (3) Declare an anonymous method
        Del del3 = delegate (string name) { Console.WriteLine($"Notification received for: {name}"); };

        // (4) Use a lambda expression
        Del del4 = name => { Console.WriteLine($"Notification received for: {name}"); };
    }
}
