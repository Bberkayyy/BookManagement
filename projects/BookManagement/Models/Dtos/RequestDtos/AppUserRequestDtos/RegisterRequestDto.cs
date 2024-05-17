using Core.Security;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.RequestDtos.AppUserRequestDtos;

public record RegisterRequestDto(string FirstName, string LastName, string Email, string Username, string Password)
{
    public static AppUser ConvertToEntity(RegisterRequestDto registerRequestDto)
    {
        HashingHelper.CreatePasswordHash(registerRequestDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
        string password = Convert.ToBase64String(passwordHash);
        return new AppUser()
        {
            FirstName = registerRequestDto.FirstName,
            LastName = registerRequestDto.LastName,
            Email = registerRequestDto.Email,
            Username = registerRequestDto.Username,
            PasswordHash = password,
            PasswordSalt = passwordSalt
        };
    }
}
