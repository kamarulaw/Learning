using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class DelegatesWIthNamedVsAnonymousMethods2_MathClass
    {
        // declare a delegate
        delegate void Del(int i, double j);

        public static void Main()
        {
            DelegatesWIthNamedVsAnonymousMethods2_MathClass m = new DelegatesWIthNamedVsAnonymousMethods2_MathClass();

            Del d = m.MultiplyNumbers;

            // Invoke the delegate object
            Console.WriteLine("Invoking the delegate using 'MultiplyNumbers':");
            for (int i = 1; i <= 5; i++)
            {
                d(i, 2);
            }

            // Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(); 
        }

        void MultiplyNumbers(int m, double n)
        {
            Console.Write(m * n + " ");
        }
    }
}
