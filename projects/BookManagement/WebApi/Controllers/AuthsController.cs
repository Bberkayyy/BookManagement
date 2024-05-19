using Core.Security.Jwt;
using Core.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDtos.AppUserRequestDtos;
using Models.Dtos.ResponseDtos.AppUserResponseDtos;
using Service.Abstract;

namespace WebApi.Controllers;

[Route("api/users")]
[AllowAnonymous]
[ApiController]
public class AuthsController : BaseController
{
    private readonly IAppUserService _appUserService;

    public AuthsController(IAppUserService appUserService)
    {
        _appUserService = appUserService;
    }
    [HttpPost("register")]
    public IActionResult RegisterUser(RegisterRequestDto registerRequestDto)
    {
        Response<AppUserResponseDto> result = _appUserService.Register(registerRequestDto);
        return ActionResultInstance(result);
    }
    [HttpPost("login")]
    public IActionResult UserLogin(LoginRequestDto loginRequestDto)
    {
        GetCheckAppUser value = _appUserService.Login(loginRequestDto);
        Response<TokenResponseDto> result = _appUserService.LoginControl(value);
        return ActionResultInstance(result);
    }
}
