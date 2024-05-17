using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.AppRoleRequestDtos;

public record AppRoleAddRequestDto(string Name)
{
    public static AppRole ConvertToEntity(AppRoleAddRequestDto addRequestDto)
    {
        return new AppRole()
        {
            Name = addRequestDto.Name,
        };
    }
}
