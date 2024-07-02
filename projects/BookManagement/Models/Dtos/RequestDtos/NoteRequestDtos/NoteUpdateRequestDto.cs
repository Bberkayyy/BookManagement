using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.NoteRequestDtos;

public record NoteUpdateRequestDto(Guid Id, Guid BookId, Guid AppUserId, string Content, bool IsPrivate) : RequestDto
{
    public static Note ConvertToEntity(NoteUpdateRequestDto updateRequestDto)
    {
        return new Note()
        {
            Id = updateRequestDto.Id,
            BookId = updateRequestDto.BookId,
            AppUserId = updateRequestDto.AppUserId,
            Content = updateRequestDto.Content,
            IsPrivate = updateRequestDto.IsPrivate
        };
    }
}
