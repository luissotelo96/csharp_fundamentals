using Xunit;

namespace GradeBook.Tests;

public class TypeTest
{
    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        //arrange
        var book1 = GetBook("Libro 1");
        var book2 = GetBook("Libro 2");
        Assert.NotSame(book1, book2);
    }

    [Fact]
    public void TwoVarCanReferencesSameObject()
    {
        //arrange
        var book1 = GetBook("Libro 1");
        var book2 = book1;

        // assert
        Assert.Same(book1, book2);
        Assert.True(object.ReferenceEquals(book1, book2));
    }

    [Fact]
    public void CanSetNameFromReference()
    {
        var book1 = GetBook("Libro 1");
        SetNameBook(book1, "New Name");

        Assert.Equal("New Name", book1.Name);
    }

    [Fact]
    public void CSharpIsPassByValue()
    {
        var book1 = GetBook("Libro 1");
        GetBookSetName(book1, "New Name");

        Assert.Equal("Libro 1", book1.Name);
    }

    [Fact]
    public void CSharpCanPassByReference()
    {
        var book1 = GetBook("Libro 1");
        GetBookSetName(ref book1, "New Name");

        Assert.Equal("New Name", book1.Name);
    }

    [Fact]
    public void Test1()
    {
        var x = 3;
        SetInt(ref x);

        Assert.Equal(45, x);
    }

    private void SetInt(ref int x)
    {
        x = 45;
    }

    Book GetBook(string name){
        return new Book(name);
    }

    public void SetNameBook(Book book, string name){
        book.Name = name;        
    }

    public void GetBookSetName(ref Book book,string name)
    {
        book = new Book(name);
    }

    public void GetBookSetName(Book book, string name)
    {
        book = new Book(name);
    }
}