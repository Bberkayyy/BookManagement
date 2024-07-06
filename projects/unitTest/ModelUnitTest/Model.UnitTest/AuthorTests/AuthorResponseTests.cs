using Models.Dtos.ResponseDtos.AuthorResponseDtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTest.AuthorTests;

public class AuthorResponseTests
{
    [Test]
    public void AuthorResponseDto_ConvertToResponse_ShouldReturnResponse()
    {
        //Arrenge
        Author author = new()
        {
            Id = Guid.NewGuid(),
            FirstName = "AuthorTestFirstName",
            LastName = "AuthorTestLastName",
            Country = "AuthorTestCountry",
            Books = new List<Book>()
        };
        //Act
        var response = AuthorResponseDto.ConvertToResponse(author);
        //Assert
        Assert.AreEqual(author.Id, response.Id);
        Assert.AreEqual(author.FirstName + " " + author.LastName, response.FullName);
        Assert.AreEqual(author.Country, response.Country);
    }
}
