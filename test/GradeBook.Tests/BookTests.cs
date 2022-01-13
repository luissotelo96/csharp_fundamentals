using Xunit;

namespace GradeBook.Tests;

public class BookTests
{
    [Fact]
    public void BookCalculatesAndAverageGrade()
    {
        //arrange
        var book = new Book("Libro prueba");
        book.AddGrade(4.8);
        book.AddGrade(2.3);
        book.AddGrade(4.1);
        
        //act
        var stats = book.GetStadistics();

        // assert
        Assert.Equal(3.73, stats.Average, 2);
        Assert.Equal(4.8, stats.High, 2);
        Assert.Equal(2.3, stats.Low, 2);
        Assert.Equal('C', stats.Letter);
    }
}