using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDtos.BookResponseDtos;

public record BookResponseDto(Guid Id, string Name, string Description, decimal Price, int Stock, string ImageUrl, Guid CategoryId, Guid AuthorId, int ShelfId) : ResponseDto
{
    public static BookResponseDto ConvertToResponse(Book entity)
    {
        return new BookResponseDto(Id: entity.Id,
                                   Name: entity.Name,
                                   Description: entity.Description,
                                   Price: entity.Price,
                                   Stock: entity.Stock,
                                   ImageUrl: entity.ImageUrl,
                                   CategoryId: entity.CategoryId,
                                   AuthorId: entity.AuthorId,
                                   ShelfId: entity.ShelfId);
    }
}
