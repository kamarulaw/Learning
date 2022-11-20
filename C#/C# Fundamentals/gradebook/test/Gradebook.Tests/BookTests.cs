using System; 
using Xunit;  
using GradeBook; 

namespace Gradebook.Tests
{
    public class BookTests
    {
        [Fact]
        public void CheckAddition()
        {
            // arrange
            var x = 5; 
            var y = 2; 
            var expected = 7; 

            // act
            var actual = x+y;
            
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookCalculatesAverageGrade()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics(); 

            // assert
            Assert.Equal(85.6, result.averageGrade, 1); 
            Assert.Equal(90.5, result.maxGrade, 1);
            Assert.Equal(77.3, result.minGrade, 1);
            Assert.Equal('B', result.letter);
        }

    }
}