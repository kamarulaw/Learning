// a set of classes for handling a bookstore
using System.Collections; 

namespace Bookstore
{
    public struct Book
    {
        public string Title;
        public string Author;
        public decimal Price;
        public bool Paperback;
        
        public Book(string title, string author, decimal price, bool paperback)
        {
            Title = title; Author = author; Price = price; Paperback = paperback;
        }

        // delcare a delegate type for processing a book
        public delegate void ProcessBookCallBack(Book book);

        // maintains a book database
        public class BookDB
        {
            // list of all books in the database: 
            ArrayList list = new ArrayList(); 

            public void AddBook(string title, string author, decimal price, bool paperBack)
            {
                list.Add(new Book(title, author, price, paperBack));
            }

            public void ProcessPaperbackBooks(ProcessBookCallBack processBook)
            {
                foreach (Book b in list)
                {
                    if (b.Paperback)
                    {
                        processBook(b); 
                    }
                }
            }
        }
    }
}