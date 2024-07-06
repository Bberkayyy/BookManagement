using Models.Dtos.RequestDtos.AuthorRequestDtos;
using Models.Dtos.RequestDtos.AuthorRequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTest.AuthorTests;

public class AuthorRequestTests
{
    private AuthorAddRequestDto addDto;
    private AuthorUpdateRequestDto updateDto;
    [SetUp]
    public void SetUp()
    {
        addDto = new AuthorAddRequestDto(FirstName: "TestAuthorFirstName", LastName: "TestAuthorLastName", Country: "TestCountry");
        updateDto = new AuthorUpdateRequestDto(Id: Guid.NewGuid(), FirstName: "TestAuthorFirstName", LastName: "TestAuthorLastName", Country: "TestCountry");
    }
    [Test]
    public void AuthorAddRequestDto_ConvertToEntity_ShouldReturnAuthor()
    {
        var author = AuthorAddRequestDto.ConvertToEntity(addDto);

        Assert.AreEqual(addDto.FirstName, author.FirstName);
        Assert.AreEqual(addDto.LastName, author.LastName);
        Assert.AreEqual(addDto.Country, author.Country);
    }
    [Test]
    public void AuthorUpdateRequestDto_ConvertToEntity_ShouldReturnAuthor()
    {
        var author = AuthorUpdateRequestDto.ConvertToEntity(updateDto);

        Assert.AreEqual(updateDto.Id, author.Id);
        Assert.AreEqual(updateDto.FirstName, author.FirstName);
        Assert.AreEqual(updateDto.LastName, author.LastName);
        Assert.AreEqual(updateDto.Country, author.Country);
    }
}
