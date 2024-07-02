using Core.Persistence.DtoBaseModel;
using Models.Dtos.ResponseDtos.ShelfResponseDtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDtos.BookResponseDtos;

public record BookResponseForSearchDto(Guid Id, string Name, string Description, decimal Price, int Stock, string ImageUrl, string CategoryName, string AuthorName, ShelfResponseDto Shelf) : ResponseDto
{
    public static BookResponseForSearchDto ConvertToResponse(Book entity)
    {
        return new BookResponseForSearchDto(Id: entity.Id,
                                   Name: entity.Name,
                                   Description: entity.Description,
                                   Price: entity.Price,
                                   Stock: entity.Stock,
                                   ImageUrl: entity.ImageUrl,
                                   CategoryName: entity.Category.Name,
                                   AuthorName: entity.Author.FirstName + " " + entity.Author.LastName,
                                   Shelf: ShelfResponseDto.ConvertToResponse(entity.Shelf));
    }
}
