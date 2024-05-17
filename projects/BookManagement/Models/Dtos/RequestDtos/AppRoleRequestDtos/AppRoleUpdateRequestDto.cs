using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.AppRoleRequestDtos;

public record AppRoleUpdateRequestDto(int id, string Name)
{
    public static AppRole ConvertToEntity(AppRoleUpdateRequestDto updateRequestDto)
    {
        return new AppRole()
        {
            Id = updateRequestDto.id,
            Name = updateRequestDto.Name,
        };
    }
}
