using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Cars
{ 
    public class Program
    {
        static void Main(String[] args)
        {
            // Read in each row from CSV file
            var cars = ProcessFile("C:\\Users\\adelawal.REDMOND\\OneDrive - Microsoft\\LINQ Fundamentals\\Cars\\fuel.csv");

            // Ensure each car has been read in by outputting cars
            // foreach (var car in cars)
            // {
            //    Console.WriteLine(car.Name);
            // }

            // Sort cars by efficiency and output the top ten results
            var query = cars.OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name);
            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }  
            
            // Stopped at 5: Filter, Ordering, & Projecting - Finding the Most Fuel Efficient..

        }

        // Extention Method Syntax
        private static List<Car> ProcessFile(string path)
        {
            return 
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    .Select(Car.ParseFromCsv)
                    .ToList();
        }

        // Query Method Syntax
        private static List<Car> ProcessFile2(string path)
        {
            var query =
                from line in File.ReadAllLines(path).Skip(1)
                where line.Length > 1
                select Car.ParseFromCsv(line); 
            return query.ToList();
        }
    }
}
