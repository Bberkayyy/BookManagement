using Core.Shared;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDtos.NoteRequestDtos;
using Models.Dtos.ResponseDtos.NoteResponseDtos;
using Service.Abstract;

namespace WebApi.Controllers;

[Route("api/notes")]
[ApiController]
public class NotesController : BaseController
{
    private readonly INoteService _noteService;

    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        Response<List<NoteResponseDto>> result = _noteService.TGetAll();
        return ActionResultInstance(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        Response<NoteResponseDto> result = _noteService.TGetById(id);
        return ActionResultInstance(result);
    }
    [HttpPost]
    public IActionResult Create(NoteAddRequestDto addRequestDto)
    {
        Response<NoteResponseDto> result = _noteService.TAdd(addRequestDto);
        return ActionResultInstance(result);
    }
    [HttpPut]
    public IActionResult Update(NoteUpdateRequestDto updateRequestDto)
    {
        Response<NoteResponseDto> result = _noteService.TUpdate(updateRequestDto);
        return ActionResultInstance(result);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        Response<NoteResponseDto> result = _noteService.TDelete(id);
        return ActionResultInstance(result);
    }
    [HttpGet("{bookId}/notes")]
    public IActionResult GetBookNotesWithPrivacyLevel(Guid bookdId)
    {
        Response<List<NoteResponseDto>> result = _noteService.TGetBookNotesWithPrivacyLevel(bookdId);
        return ActionResultInstance(result);
    }
}
