using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Queries
{
    public static class MyLinq
    {
        public static IEnumerable<double> Random()
        {
            var random = new Random(); 
            while (true)
            {
                yield return random.NextDouble(); 
            }
        }
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T,bool> predicate)
        {
            var result = new List<T>();
            foreach (var elem in source)
            {
                if (predicate(elem))
                {
                    result.Add(elem);
                }
            }
            return result; 
        }

        public static IEnumerable<T> Filter2<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var elem in source)
            {
                if (predicate(elem))
                {
                    // yield return gives us deferred execution behavior
                    // deferred execution: 
                    yield return elem; 
                }
            }
        }
    }
}
