using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.BookRequestDtos;

public record BookAddRequestDto(string Name, string Description, decimal Price, int Stock, string ImageUrl, Guid CategoryId, Guid AuthorId, int ShelfId) : RequestDto
{
    public static Book ConvertToEntity(BookAddRequestDto addRequestDto)
    {
        return new Book()
        {
            Name = addRequestDto.Name,
            Description = addRequestDto.Description,
            Price = addRequestDto.Price,
            Stock = addRequestDto.Stock,
            ImageUrl = addRequestDto.ImageUrl,
            CategoryId = addRequestDto.CategoryId,
            AuthorId = addRequestDto.AuthorId,
            ShelfId = addRequestDto.ShelfId
        };
    }
}
