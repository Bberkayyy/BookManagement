using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.AuthorRequestDtos;

public record AuthorUpdateRequestDto(Guid Id, string FirstName, string LastName, string Phone, string Email, int Age)
{
    public static Author ConvertToEntity(AuthorUpdateRequestDto updateRequestDto)
    {
        return new Author()
        {
            Id = updateRequestDto.Id,
            FirstName = updateRequestDto.FirstName,
            LastName = updateRequestDto.LastName,
            Phone = updateRequestDto.Phone,
            Email = updateRequestDto.Email,
            Age = updateRequestDto.Age
        };
    }
}
