using Core.Security;
using Core.Security.Jwt;
using Core.Shared;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.AppUserRequestDtos;
using Models.Dtos.ResponseDtos.AppUserResponseDtos;
using Models.Dtos.ResponseDtos.AuthorResponseDtos;
using Models.Entities;
using Service.Abstract;
using Service.ServiceRules.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete;

public class AppUserManager : IAppUserService
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly IAppUserRoleRepository _appUserRoleRepository;
    private readonly IRegisterRules _registerRules;

    public AppUserManager(IAppUserRepository appUserRepository, IRegisterRules registerRules, IAppUserRoleRepository appUserRoleRepository)
    {
        _appUserRepository = appUserRepository;
        _registerRules = registerRules;
        _appUserRoleRepository = appUserRoleRepository;
    }

    public GetCheckAppUser Login(LoginRequestDto loginRequestDto)
    {
        GetCheckAppUser checkUser = new();
        AppUser? user = _appUserRepository.GetByFilter(x => x.Email == loginRequestDto.Email, include: x => x.Include(x => x.AppUserRoles));
        if (user != null && HashingHelper.VerifyPasswordHash(loginRequestDto.Password, Convert.FromBase64String(user.PasswordHash), user.PasswordSalt))
        {
            checkUser.Username = user.Username;
            checkUser.Id = user.Id.ToString();
            checkUser.Roles = _appUserRoleRepository.GetAll(x => x.AppUserId == user.Id, include: x => x.Include(x => x.Role)).Select(x => x.Role.Name).ToArray();
            checkUser.IsExists = true;
        }
        else
        {
            checkUser.IsExists = false;
        }
        return checkUser;
    }

    public Response<AppUserResponseDto> Register(RegisterRequestDto registerRequestDto)
    {
        _registerRules.FirstNameCanNotBeNullOrWhiteSpace(registerRequestDto.FirstName);
        _registerRules.LastNameCanNotBeNullOrWhiteSpace(registerRequestDto.LastName);
        _registerRules.UsernameCanNotBeNullOrWhireSpace(registerRequestDto.Username);
        _registerRules.PasswordCanNotBeNullOrWhiteSpace(registerRequestDto.Password);
        _registerRules.PasswordLengthMustBeAtLeast8Character(registerRequestDto.Password);
        _registerRules.EmailCanNotBeNullOrWhiteSpace(registerRequestDto.Email);
        _registerRules.EmailMustBeUnique(registerRequestDto.Email);
        AppUser user = RegisterRequestDto.ConvertToEntity(registerRequestDto);
        _appUserRepository.Add(user);
        AppUserResponseDto response = AppUserResponseDto.ConvertToResponse(user);
        return new Response<AppUserResponseDto>()
        {
            Data = response,
            Message = "User saved successfully!",
            StatusCode = System.Net.HttpStatusCode.Created
        };
    }

    //public Response<AppUserResponseDto> TDelete(Guid id)
    //{
    //    AppUser? user = _appUserRepository.GetById(id);
    //    _appUserRepository.Delete(user);
    //    return new Response<AppUserResponseDto>()
    //    {
    //        Message = "User deleted successfully!",
    //        StatusCode = System.Net.HttpStatusCode.OK
    //    };
    //}

    //public Response<List<AppUserResponseDto>> TGetAll(Expression<Func<AppUser, bool>>? predicate = null, Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null)
    //{
    //    List<AppUser> users = _appUserRepository.GetAll(predicate, include);
    //    List<AppUserResponseDto> response = users.Select(x => AppUserResponseDto.ConvertToResponse(x)).ToList();
    //    return new Response<List<AppUserResponseDto>>()
    //    {
    //        Data = response,
    //        StatusCode = System.Net.HttpStatusCode.OK
    //    };
    //}

    //public Response<AppUserResponseDto> TGetByFilter(Expression<Func<AppUser, bool>> predicate, Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null)
    //{
    //    AppUser? user = _appUserRepository.GetByFilter(predicate, include);
    //    AppUserResponseDto response = AppUserResponseDto.ConvertToResponse(user);
    //    return new Response<AppUserResponseDto>()
    //    {
    //        Data = response,
    //        StatusCode = System.Net.HttpStatusCode.OK
    //    };
    //}

    //public Response<AppUserResponseDto> TGetById(Guid id, Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null)
    //{
    //    AppUser? user = _appUserRepository.GetById(id, include);
    //    AppUserResponseDto response = AppUserResponseDto.ConvertToResponse(user);
    //    return new Response<AppUserResponseDto>()
    //    {
    //        Data = response,
    //        StatusCode = System.Net.HttpStatusCode.OK
    //    };
    //}
}
