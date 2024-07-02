using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDtos.ShelfResponseDtos;

public record ShelfResponseDto(int Id, Guid BookId, string ShelfCode, string Section, int Floor) : ResponseDto
{
    public static ShelfResponseDto ConvertToResponse(Shelf entity)
    {
        return new ShelfResponseDto(Id: entity.Id,
                                    BookId: entity.BookId,
                                    ShelfCode: entity.ShelfCode,
                                    Section: entity.Section,
                                    Floor: entity.Floor);
    }
}
