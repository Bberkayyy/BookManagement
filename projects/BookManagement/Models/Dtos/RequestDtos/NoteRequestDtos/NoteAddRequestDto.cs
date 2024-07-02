using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.NoteRequestDtos;

public record NoteAddRequestDto(Guid BookId, Guid AppUserId, string Content, bool IsPrivate) : RequestDto
{
    public static Note ConvertToEntity(NoteAddRequestDto addRequestDto)
    {
        return new Note()
        {
            BookId = addRequestDto.BookId,
            AppUserId = addRequestDto.AppUserId,
            Content = addRequestDto.Content,
            IsPrivate = addRequestDto.IsPrivate
        };
    }
}
