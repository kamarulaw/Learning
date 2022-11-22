using System.Collections.Generic; 
using System.Linq;
using System;
using System.Runtime.ExceptionServices;

namespace Queries
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            // Streaming example
            var numbers = MyLinq.Random().Where(x => x > 0.5).Take(10);
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine(); 

            var movies = new List<Movie>()
            {
                new Movie{Title="The Dark Knight", Rating=8.9f,Year=2008 },
                new Movie{Title="The King's Speech", Rating=8.0f,Year=2010 },
                new Movie{Title="Casablanca", Rating=8.5f,Year=1942 },
                new Movie{Title="Star Wars V", Rating=8.7f,Year=1980 }
            };

            // Filter movies using Where
            var query = movies.Where(m => m.Year > 2000);
            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }
            Console.WriteLine(); 

            // Filter movies using custom filter
            var query2 = movies.Filter(m => m.Year > 2000);
            foreach (var movie in query2)
            {
                Console.WriteLine(movie.Title);
            }
            Console.WriteLine(); 

            // Filter movies using custom filter (uses yield return key phrase to create similar behavior to Where)
            var query3 = movies.Filter2(m => m.Year > 2000);
            foreach (var movie in query2)
            {
                Console.WriteLine(movie.Title);
            }
            Console.WriteLine();

            // where and take are streaming operators
            // orderby and orderbydescending are not streaming operators

            // Output movies from previous query using GetEnumerator()
            var enumerator = query3.GetEnumerator(); 
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }
            Console.WriteLine();

            // Filter movies using query syntax
            var query4 = from movie in movies
                         where movie.Year > 2000
                         orderby movie.Rating descending
                         select movie;
            foreach (var movie in query4)
            {
                Console.WriteLine(movie);
            }
        }
    }
}
