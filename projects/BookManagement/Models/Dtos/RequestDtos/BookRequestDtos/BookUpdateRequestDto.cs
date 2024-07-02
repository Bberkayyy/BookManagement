using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.BookRequestDtos;

public record BookUpdateRequestDto(Guid Id, string Name, string Description, decimal Price, int Stock, string ImageUrl, Guid CategoryId, Guid AuthorId
    , int ShelfId) : RequestDto
{
    public static Book ConvertToEntity(BookUpdateRequestDto updateRequestDto)
    {
        return new Book()
        {
            Id = updateRequestDto.Id,
            Name = updateRequestDto.Name,
            Description = updateRequestDto.Description,
            Price = updateRequestDto.Price,
            Stock = updateRequestDto.Stock,
            ImageUrl = updateRequestDto.ImageUrl,
            CategoryId = updateRequestDto.CategoryId,
            AuthorId = updateRequestDto.AuthorId,
            ShelfId = updateRequestDto.ShelfId
        };
    }
}
