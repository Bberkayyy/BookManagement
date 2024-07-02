using Core.Persistence.DtoBaseModel;
using Models.Entities;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.NoteShareRequestDtos;

public record NoteShareAddRequestDto(Guid NoteId, PrivacyLevel PrivacyLevel) : RequestDto
{
    public static NoteShare ConvertToEntity(NoteShareAddRequestDto addRequestDto)
    {
        return new NoteShare()
        {
            NoteId = addRequestDto.NoteId,
            PrivacyLevel = addRequestDto.PrivacyLevel,
        };
    }
}
