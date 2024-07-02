using Core.Persistence.DtoBaseModel;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDtos.NoteResponseDtos;

public record NoteResponseDto(Guid Id, Guid BookId, Guid AppUserId, string Content, bool IsPrivate) : ResponseDto
{
    public static NoteResponseDto ConvertToResponse(Note entity)
    {
        return new NoteResponseDto(Id: entity.Id,
                                   BookId: entity.BookId,
                                   AppUserId: entity.AppUserId,
                                   Content: entity.Content,
                                   IsPrivate: entity.IsPrivate);
    }
}
