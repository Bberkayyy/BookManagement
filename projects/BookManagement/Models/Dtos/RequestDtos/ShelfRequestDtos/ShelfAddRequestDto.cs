using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.ShelfRequestDtos;

public record ShelfAddRequestDto(Guid BookId, string ShelfCode, string Section, int Floor) : RequestDto
{
    public static Shelf ConvertToEntity(ShelfAddRequestDto addRequestDto)
    {
        return new Shelf()
        {
            BookId = addRequestDto.BookId,
            ShelfCode = addRequestDto.ShelfCode,
            Section = addRequestDto.Section,
            Floor = addRequestDto.Floor
        };
    }
}
