using Core.Persistence.DtoBaseModel;
using Models.Dtos.ResponseDtos.NoteResponseDtos;
using Models.Entities;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDtos.NoteShareResponseDtos;

public record NoteShareResponseDto(Guid Id, Guid NoteId, PrivacyLevel PrivacyLevel) : ResponseDto
{
    public static NoteShareResponseDto ConvertToResponse(NoteShare entity)
    {
        return new NoteShareResponseDto(Id: entity.Id,
                                        NoteId: entity.NoteId,
                                        PrivacyLevel: entity.PrivacyLevel);
    }
}
