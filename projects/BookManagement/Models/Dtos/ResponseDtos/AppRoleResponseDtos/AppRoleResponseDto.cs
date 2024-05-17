using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDtos.AppRoleResponseDtos;

public record AppRoleResponseDto(int id, string Name)
{
    public static AppRoleResponseDto ConvertToResponse(AppRole appRole)
    {
        return new AppRoleResponseDto(id: appRole.Id, Name: appRole.Name);
    }
}
