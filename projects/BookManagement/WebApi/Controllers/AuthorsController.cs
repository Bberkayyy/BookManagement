using Core.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDtos.AuthorRequestDtos;
using Models.Dtos.ResponseDtos.AuthorResponseDtos;
using Models.Dtos.ResponseDtos.BookResponseDtos;
using Service.Abstract;

namespace WebApi.Controllers;

[Route("api/authors")]
[Authorize(Policy = "AdminPolicy")]
[ApiController]
public class AuthorsController : BaseController
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        Response<List<AuthorResponseDto>> result = _authorService.TGetAll();
        return ActionResultInstance(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        Response<AuthorResponseDto> result = _authorService.TGetById(id);
        return ActionResultInstance(result);
    }
    [HttpPost]
    public IActionResult Create(AuthorAddRequestDto addRequestDto)
    {
        Response<AuthorResponseDto> result = _authorService.TAdd(addRequestDto);
        return ActionResultInstance(result);
    }
    [HttpPut]
    public IActionResult Update(AuthorUpdateRequestDto updateRequestDto)
    {
        Response<AuthorResponseDto> result = _authorService.TUpdate(updateRequestDto);
        return ActionResultInstance(result);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        Response<AuthorResponseDto> result = _authorService.TDelete(id);
        return ActionResultInstance(result);
    }
    [HttpGet("{authorId}/books")]
    public IActionResult GetAuthorBooks(Guid authorId)
    {
        Response<List<BookResponseWithRelationshipsDto>> result = _authorService.TGetAuthorBooks(authorId);
        return ActionResultInstance(result);
    }
}
