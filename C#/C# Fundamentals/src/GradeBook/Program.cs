using System; 
using System.Collections.Generic;
using System.Diagnostics;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * var p = new Program(); 
             * Program.Main(args);
             * Main is static => objects cannot acces the class as an instance method, only the class can access static methods
             * object references are required for non-static fields
            */

            // InMemory Gradebook
            var book = new InMemoryBook("Scott");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            var bookstats = book.GetStatistics();   
            //Console.WriteLine($"The lowest grade is {bookstats.minGrade}");
            //Console.WriteLine($"The highest grade is {bookstats.maxGrade}");
            //Console.WriteLine($"The average grade is {bookstats.Average}");
            //Console.WriteLine($"The letter grade is {bookstats.Letter}");

            // InMemory Gradebook with grades read in from user on command line 
            var book2 = new InMemoryBook("Console Input Book");
            EnterGrades(book2);

            var book2stats = book2.GetStatistics();
            Console.WriteLine($"The lowest grade is {book2stats.minGrade}");
            Console.WriteLine($"The highest grade is {book2stats.maxGrade}");
            Console.WriteLine($"The average grade is {book2stats.Average}");
            Console.WriteLine($"The letter grade is {book2stats.Letter}");

            // DiskMemory Gradebook with grades read in from user on command line
            var book3 = new DiskBook("Console Input Book");
            EnterGrades(book3);

            var book3stats = book3.GetStatistics();
            Console.WriteLine($"The lowest grade is {book3stats.minGrade}");
            Console.WriteLine($"The highest grade is {book3stats.maxGrade}");
            Console.WriteLine($"The average grade is {book3stats.Average}");
            Console.WriteLine($"The letter grade is {book3stats.Letter}");
            
        }

        public static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine(); 
                if (input == "q")
                {
                    break; 
                }
                try
                { 
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added..");
        }
    }
}