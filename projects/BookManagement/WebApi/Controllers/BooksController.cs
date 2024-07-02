using Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDtos.BookRequestDtos;
using Models.Dtos.ResponseDtos.BookResponseDtos;
using Service.Abstract;

namespace WebApi.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController : BaseController
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        Response<List<BookResponseDto>> result = _bookService.TGetAll();
        return ActionResultInstance(result);
    }
    [HttpGet("bookswithshelfinfo")]
    public IActionResult GetBooksWithShelfInfo()
    {
        Response<List<BookResponseWithShelfInfoDto>> result = _bookService.TGetBooksWithShelfInfo();
        return ActionResultInstance(result);
    }
    [HttpGet("search")]
    public IActionResult GetSearchedBooks(string? name, string? categoryName, string? authorName, string? shelfCode)
    {
        Response<List<BookResponseForSearchDto>> result = _bookService.TSearchBooks(name, categoryName, authorName, shelfCode);
        return ActionResultInstance(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        Response<BookResponseDto> result = _bookService.TGetById(id);
        return ActionResultInstance(result);
    }
    [HttpPost]
    public IActionResult Create(BookAddRequestDto addRequestDto)
    {
        Response<BookResponseDto> result = _bookService.TAdd(addRequestDto);
        return ActionResultInstance(result);
    }
    [HttpPut]
    public IActionResult Update(BookUpdateRequestDto updateRequestDto)
    {
        Response<BookResponseDto> result = _bookService.TUpdate(updateRequestDto);
        return ActionResultInstance(result);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        Response<BookResponseDto> result = _bookService.TDelete(id);
        return ActionResultInstance(result);
    }
}
