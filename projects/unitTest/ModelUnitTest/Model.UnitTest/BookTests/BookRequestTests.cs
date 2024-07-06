using Models.Dtos.RequestDtos.BookRequestDtos;

namespace Model.UnitTest.BookTests;

public class BookRequestTests
{
    [Test]
    public void BookAddRequestDto_ConvertToEntity_ShouldReturnBook()
    {
        //Arrenge
        BookAddRequestDto addTestDto = new(
            Name: "Test Book",
            Description: "Test Description",
            Price: 19.99m,
            Stock: 9,
            ImageUrl: "Test Image",
            CategoryId: Guid.NewGuid(),
            AuthorId: Guid.NewGuid(),
            ShelfId: 1
            );
        //Act
        var book = BookAddRequestDto.ConvertToEntity(addTestDto);
        //Assert
        Assert.AreEqual(addTestDto.Name, book.Name);
        Assert.AreEqual(addTestDto.Description, book.Description);
        Assert.AreEqual(addTestDto.Price, book.Price);
        Assert.AreEqual(addTestDto.Stock, book.Stock);
        Assert.AreEqual(addTestDto.ImageUrl, book.ImageUrl);
        Assert.AreEqual(addTestDto.CategoryId, book.CategoryId);
        Assert.AreEqual(addTestDto.AuthorId, book.AuthorId);
        Assert.AreEqual(addTestDto.ShelfId, book.ShelfId);
    }
    [Test]
    public void BookUpdateRequestDto_ConvertToEntity_ShouldReturnBook()
    {
        //Arrenge
        BookUpdateRequestDto updateTestDto = new(
            Id: Guid.NewGuid(),
            Name: "Test Book",
            Description: "Test Description",
            Price: 19.99m,
            Stock: 9,
            ImageUrl: "Test Image",
            CategoryId: Guid.NewGuid(),
            AuthorId: Guid.NewGuid(),
            ShelfId: 1
            );
        //Act
        var book = BookUpdateRequestDto.ConvertToEntity(updateTestDto);
        //Assert
        Assert.AreEqual(updateTestDto.Id, book.Id);
        Assert.AreEqual(updateTestDto.Name, book.Name);
        Assert.AreEqual(updateTestDto.Description, book.Description);
        Assert.AreEqual(updateTestDto.Price, book.Price);
        Assert.AreEqual(updateTestDto.Stock, book.Stock);
        Assert.AreEqual(updateTestDto.ImageUrl, book.ImageUrl);
        Assert.AreEqual(updateTestDto.CategoryId, book.CategoryId);
        Assert.AreEqual(updateTestDto.AuthorId, book.AuthorId);
        Assert.AreEqual(updateTestDto.ShelfId, book.ShelfId);
    }
}
