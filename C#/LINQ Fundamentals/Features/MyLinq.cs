using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    public static class MyLinq
    {
        // this keyword for first parameter makes the method an extension method
        // gives us the power to use Count as an instance method instead of a static method
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            int count = 0;
            foreach (var elem in sequence)
            {
                count++;
            }
            return count; 
        }
    }
}
