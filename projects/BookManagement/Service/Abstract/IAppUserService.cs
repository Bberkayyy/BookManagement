using Core.Security.Jwt;
using Core.Shared;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.AppUserRequestDtos;
using Models.Dtos.ResponseDtos.AppUserResponseDtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract;

public interface IAppUserService
{
    Response<AppUserResponseDto> Register(RegisterRequestDto registerRequestDto);
    GetCheckAppUser Login(LoginRequestDto loginRequestDto);
    Response<TokenResponseDto> LoginControl(GetCheckAppUser getCheckAppUser);
    //Response<AppUserResponseDto> TDelete(Guid id);
    //Response<List<AppUserResponseDto>> TGetAll(Expression<Func<AppUser, bool>>? predicate = null, Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null);
    //Response<AppUserResponseDto> TGetById(Guid id, Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null);
    //Response<AppUserResponseDto> TGetByFilter(Expression<Func<AppUser, bool>> predicate, Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null);
}
