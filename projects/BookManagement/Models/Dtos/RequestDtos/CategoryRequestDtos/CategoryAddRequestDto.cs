using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.CategoryRequestDtos;

public record CategoryAddRequestDto(string Name) : RequestDto
{
    public static Category ConvertToEntity(CategoryAddRequestDto addRequestDto)
    {
        return new Category()
        {
            Name = addRequestDto.Name,
        };
    }
}
