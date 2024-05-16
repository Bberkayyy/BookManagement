using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.AuthorRequestDtos;

public record AuthorUpdateRequestDto(Guid Id, string FirstName, string LastName, string Country) : RequestDto
{
    public static Author ConvertToEntity(AuthorUpdateRequestDto updateRequestDto)
    {
        return new Author()
        {
            Id = updateRequestDto.Id,
            FirstName = updateRequestDto.FirstName,
            LastName = updateRequestDto.LastName,
            Country = updateRequestDto.Country,
        };
    }
}
