using System; 
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks; 
namespace Features
{
   
    public class Program
    { 
        static void Main(string[] args)
        {
            // Lambda expressino for returning the square of a number
            Func<int, int> square = e => e*e; 
            Console.WriteLine($"3^2: {square(3)}");

            // Last generic type parameter always describes the return type
            // The generic types parameters before the last one describe the function input parameter types
            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine($"3+5: {add(3,5)}");

            // Explicit typing works, but is optional
            Func<int, int, int> add2 = (int x, int y) => x + y;
            Console.WriteLine($"3+5: {add2(3, 5)}");

            // Curly braces are also allowed when defining lambda expressions, but if you you use them then you need return
            Func<int, int, int> add3 = (x, y) =>
            {
                int temp = x + y;
                return temp;
            };
            Console.WriteLine($"3+5: {add3(3, 5)}"); 

            // Action always returns void => incoming generic types only define incoming parameters to the method
            // Action<int> => public void (int x) {}
            Action<int> write = x => Console.WriteLine(x);
            write(add(square(9), 18));
            Console.WriteLine();

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Scott"},
                new Employee { Id = 2, Name = "Chris"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Alex"}
            };

            // Make use of Extension method defined in MyLinq.cs
            Console.WriteLine($"There are {sales.Count()} elements in the 'sales' list");
            Console.WriteLine($"There are {developers.Count()} elements in the 'developers' list");

            // Syntax to iterate through a data structure that inherits IEnumerable<T>
            // Similar to iterating through a vector in C++ using vec.begin()
            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Id);
                Console.WriteLine(enumerator.Current.Name);
            }
            Console.WriteLine(); 

            // Print out names of Employees whose name start with letter S using method
            foreach (var emp in developers.Where(NameStartsWithS))
            {
                Console.WriteLine(emp.Name);
            }

            // Print out names of Employees whose names start with letter S using Anonymous Methods
            foreach (var emp in developers.Where(delegate (Employee employee)
                                                       {return employee.Name.StartsWith('S');}))
            {
                Console.WriteLine(emp.Name);
            }

            // Print out names of Employees whose names tart with letter S using Lambda Expressions
            foreach (var emp in developers.Where(e => e.Name.StartsWith('S')))
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();

            // Print out names of Employees whose names are five characters long in alpha order using Method Syntax
            foreach (var emp in developers.Where(e => e.Name.Length == 5).OrderBy(e => e.Name))
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine(); 

            // Print out names of Employees whose names are five characters long in alpha using Method Syntax. Order after saving as a list
            var query = developers.Where(e => e.Name.Length == 5).OrderBy(e => e.Name);
            foreach (var emp in query)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine(); 

            // Print out names of Employees whose names are five characters long in alpha order using Query Syntax
            var query2 = from developer in developers
                         where developer.Name.Length == 5
                         orderby developer.Name
                         select developer; 
            foreach (var emp in query2)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine(); 
        }
        private static bool NameStartsWithS(Employee employee)
        {
            return employee.Name.StartsWith('S');
        }
    }

}