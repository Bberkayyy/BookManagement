using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.CategoryRequestDtos;

public record CategoryUpdateRequestDto(Guid Id, string Name) : RequestDto
{
    public static Category ConvertToEntity(CategoryUpdateRequestDto updateRequestDto)
    {
        return new Category()
        {
            Id = updateRequestDto.Id,
            Name = updateRequestDto.Name,
        };
    }
}
