using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.BookRequestDtos;

public record BookAddRequestDto(string Name, string Description, decimal Price, int Stock, Guid CategoryId, Guid AuthorId)
{
    public static Book ConvertToEntity(BookAddRequestDto addRequestDto)
    {
        return new Book()
        {
            Name = addRequestDto.Name,
            Description = addRequestDto.Description,
            Price = addRequestDto.Price,
            Stock = addRequestDto.Stock,
            CategoryId = addRequestDto.CategoryId,
            AuthorId = addRequestDto.AuthorId
        };
    }
}
