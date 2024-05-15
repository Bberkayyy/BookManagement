using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.AuthorRequestDtos;

public record AuthorAddRequestDto(string FirstName, string LastName, string Phone, string Email, int Age)
{
    public static Author ConvertToEntity(AuthorAddRequestDto addRequestDto)
    {
        return new Author()
        {
            FirstName = addRequestDto.FirstName,
            LastName = addRequestDto.LastName,
            Phone = addRequestDto.Phone,
            Email = addRequestDto.Email,
            Age = addRequestDto.Age
        };
    }
}
