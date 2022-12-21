using Bookstore; 

namespace Bookstore.BookTestClient
{
    public class Test
    {
        static void PrintTitle(Book b)
        {
            Console.WriteLine($"    {b.Title}");
        }

        static void Main()
        {
            var bookDB = new Book.BookDB();
            AddBooks(bookDB); // initialize the database with some books
            Console.WriteLine("Paperback Book Titles:"); // print all titles

            // create a new delegate object associated with the static method Test.PrintTitle
            bookDB.ProcessPaperbackBooks(PrintTitle);

            // get the average price of a paperback by using a PriceTotaller object
            PriceTotaller totaller = new PriceTotaller();

            // create a new delegate object associated with the non-static method AddBookToTotal on the object totaller
            bookDB.ProcessPaperbackBooks(totaller.AddBookToTotal);

            Console.WriteLine("average paperback book price: ${0:#.##}", totaller.AveragePrice());
        }

        static void AddBooks(Book.BookDB bookDB)
        {
            bookDB.AddBook("The C Programming Language", "Brian W. Kernighan and Dennis M. Ritchie", 19.95m, true);
            bookDB.AddBook("The Unicode Standard 2.0", "The Unicode Consortium", 39.95m, true);
            bookDB.AddBook("The MS0DOS Encyclopedia", "Ray Duncan", 129.95m, false);
            bookDB.AddBook("Dogbert's Clues for the Clueless", "Scott Adams", 12.00m, true);
        }
    }
}
