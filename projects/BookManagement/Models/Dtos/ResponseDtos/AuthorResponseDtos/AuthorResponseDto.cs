using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDtos.AuthorResponseDtos;

public record AuthorResponseDto(Guid Id, string FullName, string Country) : ResponseDto
{
    public static AuthorResponseDto ConvertToResponse(Author entity)
    {
        return new AuthorResponseDto(Id: entity.Id,
                                     FullName: entity.FirstName + " " + entity.LastName,
                                     Country: entity.Country
                                     );
    }
}
