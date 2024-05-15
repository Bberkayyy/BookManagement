using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDtos.BookResponseDtos;

public record BookResponseDto(Guid Id, string Name, string Description, decimal Price, int Stock, Guid CategoryId, Guid AuthorId)
{
    public static BookResponseDto ConvertToResponse(Book entity)
    {
        return new BookResponseDto(Id: entity.Id,
                                   Name: entity.Name,
                                   Description: entity.Description,
                                   Price: entity.Price,
                                   Stock: entity.Stock,
                                   CategoryId: entity.CategoryId,
                                   AuthorId: entity.AuthorId);
    }
}
