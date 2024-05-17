using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ResponseDtos.AppUserResponseDtos;

public record AppUserResponseDto(Guid Id, string FirstName, string LastName, string Email, string Username)
{
    public static AppUserResponseDto ConvertToResponse(AppUser appUser)
    {
        return new AppUserResponseDto(Id: appUser.Id,
                                      FirstName: appUser.FirstName,
                                      LastName: appUser.LastName,
                                      Email: appUser.Email,
                                      Username: appUser.Username);
    }
}
