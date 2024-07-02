using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.ShelfRequestDtos;

public record ShelfUpdateRequestDto(int Id, Guid BookId, string ShelfCode, string Section, int Floor) : RequestDto
{
    public static Shelf ConvertToEntity(ShelfUpdateRequestDto updateRequestDto)
    {
        return new Shelf()
        {
            Id = updateRequestDto.Id,
            BookId = updateRequestDto.BookId,
            ShelfCode = updateRequestDto.ShelfCode,
            Section = updateRequestDto.Section,
            Floor = updateRequestDto.Floor
        };
    }
}
