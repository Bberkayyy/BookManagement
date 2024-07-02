using Core.Persistence.DtoBaseModel;
using Models.Entities;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.NoteShareRequestDtos;

public record NoteShareUpdateRequestDto(Guid Id, Guid NoteId, PrivacyLevel PrivacyLevel) : RequestDto
{
    public static NoteShare ConvertToEntity(NoteShareUpdateRequestDto updateRequestDto)
    {
        return new NoteShare()
        {
            Id = updateRequestDto.Id,
            NoteId = updateRequestDto.NoteId,
            PrivacyLevel = updateRequestDto.PrivacyLevel
        };
    }
}
