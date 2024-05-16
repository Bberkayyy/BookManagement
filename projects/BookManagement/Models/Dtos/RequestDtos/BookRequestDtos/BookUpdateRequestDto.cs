using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.BookRequestDtos;

public record BookUpdateRequestDto(Guid Id, string Name, string Description, decimal Price, int Stock, Guid CategoryId, Guid AuthorId) : RequestDto
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
            CategoryId = updateRequestDto.CategoryId,
            AuthorId = updateRequestDto.AuthorId
        };
    }
}
