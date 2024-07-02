using Core.Shared;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.NoteRequestDtos;
using Models.Dtos.ResponseDtos.NoteResponseDtos;
using Models.Entities;
using Service.Abstract;
using Service.ServiceRules.Abstract;
using System.Linq.Expressions;

namespace Service.Concrete;

public class NoteManager : INoteService
{
    private readonly INoteRepository _noteRepository;
    private readonly INoteRules _noteRules;

    public NoteManager(INoteRepository noteRepository, INoteRules noteRules)
    {
        _noteRepository = noteRepository;
        _noteRules = noteRules;
    }

    public Response<NoteResponseDto> TAdd(NoteAddRequestDto addRequestDto)
    {
        _noteRules.BookIsExists(addRequestDto.BookId);
        _noteRules.AppUserIsExists(addRequestDto.AppUserId);
        _noteRules.ContentCanNotBeNullOrWhiteSpace(addRequestDto.Content);
        Note note = NoteAddRequestDto.ConvertToEntity(addRequestDto);
        _noteRepository.Add(note);
        NoteResponseDto response = NoteResponseDto.ConvertToResponse(note);
        return new Response<NoteResponseDto>()
        {
            Data = response,
            Message = "Note created successfully!",
            StatusCode = System.Net.HttpStatusCode.Created,
        };
    }

    public Response<NoteResponseDto> TDelete(Guid id)
    {
        _noteRules.NoteIsExists(id);
        Note? note = _noteRepository.GetById(id);
        _noteRepository.Delete(note);
        return new Response<NoteResponseDto>()
        {
            Message = "Note deleted successfully!",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<NoteResponseDto>> TGetAll(Expression<Func<Note, bool>>? predicate = null, Func<IQueryable<Note>, IIncludableQueryable<Note, object>>? include = null)
    {
        List<Note> notes = _noteRepository.GetAll(predicate, include);
        List<NoteResponseDto> response = notes.Select(x => NoteResponseDto.ConvertToResponse(x)).ToList();
        return new Response<List<NoteResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<NoteResponseDto>> TGetBookNotesWithPrivacyLevel(Guid bookId)
    {
        List<Note> notes = _noteRepository.GetBookNotesWithPrivacyLevel(bookId);
        List<NoteResponseDto> response = notes.Select(x => NoteResponseDto.ConvertToResponse(x)).ToList();
        return new Response<List<NoteResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<NoteResponseDto> TGetByFilter(Expression<Func<Note, bool>> predicate, Func<IQueryable<Note>, IIncludableQueryable<Note, object>>? include = null)
    {
        Note? note = _noteRepository.GetByFilter(predicate, include);
        NoteResponseDto response = NoteResponseDto.ConvertToResponse(note);
        return new Response<NoteResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<NoteResponseDto> TGetById(Guid id, Func<IQueryable<Note>, IIncludableQueryable<Note, object>>? include = null)
    {
        _noteRules.NoteIsExists(id);
        Note? note = _noteRepository.GetById(id, include);
        NoteResponseDto response = NoteResponseDto.ConvertToResponse(note);
        return new Response<NoteResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<NoteResponseDto> TUpdate(NoteUpdateRequestDto updateRequestDto)
    {
        _noteRules.BookIsExists(updateRequestDto.BookId);
        _noteRules.AppUserIsExists(updateRequestDto.AppUserId);
        _noteRules.ContentCanNotBeNullOrWhiteSpace(updateRequestDto.Content);
        Note note = NoteUpdateRequestDto.ConvertToEntity(updateRequestDto);
        _noteRepository.Update(note);
        NoteResponseDto response = NoteResponseDto.ConvertToResponse(note);
        return new Response<NoteResponseDto>()
        {
            Data = response,
            Message = "Note updated successfully!",
            StatusCode = System.Net.HttpStatusCode.OK,
        };
    }
}
