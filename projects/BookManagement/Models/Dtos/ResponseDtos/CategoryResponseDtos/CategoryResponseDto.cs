using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDtos.CategoryResponseDtos;

public record CategoryResponseDto(Guid Id, string Name) : ResponseDto
{
    public static CategoryResponseDto ConvertToResponse(Category entity)
    {
        return new CategoryResponseDto(Id: entity.Id,
                                       Name: entity.Name);
    }
}
