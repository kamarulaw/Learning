using System; 
using Xunit;  
using GradeBook; 

namespace Gradebook.Tests
{
    public delegate string WriteLogDelegate(string logMessage); // delegates allow you to declare a variable that you can use like a method

    public class TypeTests
    {
        int count = 0; 

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {

            WriteLogDelegate log = ReturnMessage; // log can now point to any method that returns a string and takes in a single parameter of type string as input

            log += ReturnMessage;
            log += IncrementCount; 

            var result = log("Hello");
            Assert.Equal(3, count);
        }

        string ReturnMessage(string message)
        {
            count++; 
            return message.ToUpper(); 
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower(); ;
        }


        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.name);
            Assert.Equal("Book 2", book2.name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject1()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject2()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            Assert.Equal("Book 1", book1.name);
            Assert.Equal("Book 1", book2.name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.name);
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.name);
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.name);
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        [Fact]
        public void StringBehavesLikeValueType()
        {
            string name = "Scott";
            var upper = MakeUpperCase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUpperCase(string Parameter)
        {
            return Parameter.ToUpper();
        }

        private void GetBookSetName(ref Book book, string new_name)
        {
            book = new Book(new_name);
        }

        private void GetBookSetName(Book book, string new_name)
        {
            book = new Book(new_name);
        }

        private void SetName(Book book, string new_name)
        {
            book.name = new_name;
        }

        public int GetInt()
        {
            return 3; 
        }

        private void SetInt(ref Int32 z)
        {
            z = 42; 
        }

        // structs are value types.  classes are reference types
        // string is always a reference type.  sometimes it behaves like a value type
    }
}