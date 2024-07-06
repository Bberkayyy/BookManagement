using Models.Dtos.RequestDtos.BookRequestDtos;
using Models.Dtos.ResponseDtos.BookResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Models.Dtos.ResponseDtos.ShelfResponseDtos;
using static System.Collections.Specialized.BitVector32;
using System.Drawing;
using System.Net;

namespace Model.UnitTest.BookTests;

public class BookResponseTests
{
    private Book book;
    private Category category;
    private Author author;
    private Shelf shelf;

    [SetUp]
    public void SetUp()
    {
        category = new()
        {
            Id = Guid.NewGuid(),
            Name = "Test CategoryName",
            Books = new List<Book>()
        };
        author = new()
        {
            Id = Guid.NewGuid(),
            Country = "Test Country",
            FirstName = "Test AuthorFirstName",
            LastName = "Test AuthorLastName",
            Books = new List<Book>()
        };
        shelf = new()
        {
            Id = 1,
            BookId = Guid.NewGuid(),
            ShelfCode = "Test ShelfCode",
            Section = "Test Section",
            Floor = 1,
            Books = new List<Book>()
        };
        book = new()
        {
            Id = Guid.NewGuid(),
            Name = "Test Book",
            Description = "Test Description",
            Price = 19.99m,
            Stock = 9,
            ImageUrl = "Test Image",
            CategoryId = category.Id,
            AuthorId = author.Id,
            ShelfId = shelf.Id,
            Author = author,
            Category = category,
            Shelf = shelf,
        };
        category.Books.Add(book);
        author.Books.Add(book);
        shelf.Books.Add(book);
    }
    [Test]
    public void BookResponseDto_ConvertToResponse_ShouldReturnResponse()
    {
        //Act
        var response = BookResponseDto.ConvertToResponse(book);
        //Assert
        Assert.AreEqual(book.Id, response.Id);
        Assert.AreEqual(book.Name, response.Name);
        Assert.AreEqual(book.Description, response.Description);
        Assert.AreEqual(book.Price, response.Price);
        Assert.AreEqual(book.Stock, response.Stock);
        Assert.AreEqual(book.ImageUrl, response.ImageUrl);
        Assert.AreEqual(book.CategoryId, response.CategoryId);
        Assert.AreEqual(book.AuthorId, response.AuthorId);
        Assert.AreEqual(book.ShelfId, response.ShelfId);
    }
    [Test]
    public void BookResponseForSearchDto_ConvertToResponse_ShouldReturnResponseForSearch()
    {
        //Act
        var response = BookResponseForSearchDto.ConvertToResponse(book);
        //Assert
        Assert.AreEqual(book.Id, response.Id);
        Assert.AreEqual(book.Name, response.Name);
        Assert.AreEqual(book.Description, response.Description);
        Assert.AreEqual(book.Price, response.Price);
        Assert.AreEqual(book.Stock, response.Stock);
        Assert.AreEqual(book.ImageUrl, response.ImageUrl);
        Assert.AreEqual(book.Category.Name, response.CategoryName);
        Assert.AreEqual(book.Author.FirstName + " " + book.Author.LastName, response.AuthorName);
        Assert.AreEqual(book.Shelf.Id, response.Shelf.Id);
        Assert.AreEqual(book.Shelf.ShelfCode, response.Shelf.ShelfCode);
        Assert.AreEqual(book.Shelf.Section, response.Shelf.Section);
        Assert.AreEqual(book.Shelf.Floor, response.Shelf.Floor);
    }
    [Test]
    public void BookResponseWithRelationshipsDto_ConvertToResponse_ShouldReturnResponseWithRelationships()
    {
        //Act
        var response = BookResponseWithRelationshipsDto.ConvertToResponse(book);
        //Assert
        Assert.AreEqual(book.Id, response.Id);
        Assert.AreEqual(book.Name, response.Name);
        Assert.AreEqual(book.Description, response.Description);
        Assert.AreEqual(book.Price, response.Price);
        Assert.AreEqual(book.Stock, response.Stock);
        Assert.AreEqual(book.ImageUrl, response.ImageUrl);
        Assert.AreEqual(book.Category.Name, response.CategoryName);
        Assert.AreEqual(book.Author.FirstName + " " + book.Author.LastName, response.AuthorName);
        Assert.AreEqual(book.Shelf.ShelfCode, response.ShelfCode);
    }
    [Test]
    public void BookResponseWithShelfInfoDto_ConvertToResponse_ShouldReturnResponseWithShelfInfo()
    {
        //Act
        var response = BookResponseWithShelfInfoDto.ConvertToResponse(book);
        //Assert
        Assert.AreEqual(book.Id, response.Id);
        Assert.AreEqual(book.Name, response.Name);
        Assert.AreEqual(book.Description, response.Description);
        Assert.AreEqual(book.Price, response.Price);
        Assert.AreEqual(book.Stock, response.Stock);
        Assert.AreEqual(book.ImageUrl, response.ImageUrl);
        Assert.AreEqual(book.Category.Name, response.CategoryName);
        Assert.AreEqual(book.Author.FirstName + " " + book.Author.LastName, response.AuthorName);
        Assert.AreEqual(book.Shelf.Id, response.Shelf.Id);
        Assert.AreEqual(book.Shelf.ShelfCode, response.Shelf.ShelfCode);
        Assert.AreEqual(book.Shelf.Section, response.Shelf.Section);
        Assert.AreEqual(book.Shelf.Floor, response.Shelf.Floor);
    }
}
