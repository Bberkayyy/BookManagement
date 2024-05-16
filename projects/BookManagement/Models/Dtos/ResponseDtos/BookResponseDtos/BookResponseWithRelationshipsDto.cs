using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDtos.BookResponseDtos;

public record BookResponseWithRelationshipsDto(Guid Id, string Name, string Description, decimal Price, int Stock, string CategoryName, string AuthorName) : ResponseDto
{
    public static BookResponseWithRelationshipsDto ConvertToResponse(Book entity)
    {
        return new BookResponseWithRelationshipsDto(Id: entity.Id,
                                   Name: entity.Name,
                                   Description: entity.Description,
                                   Price: entity.Price,
                                   Stock: entity.Stock,
                                   CategoryName: entity.Category.Name,
                                   AuthorName: entity.Author.FirstName + " " + entity.Author.LastName);
    }
}
