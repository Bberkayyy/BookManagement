using Core.Shared;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.NoteRequestDtos;
using Models.Dtos.ResponseDtos.BookResponseDtos;
using Models.Dtos.ResponseDtos.NoteResponseDtos;
using Models.Entities;
using System.Linq.Expressions;

namespace Service.Abstract;

public interface INoteService
{
    Response<NoteResponseDto> TAdd(NoteAddRequestDto addRequestDto);
    Response<NoteResponseDto> TUpdate(NoteUpdateRequestDto updateRequestDto);
    Response<NoteResponseDto> TDelete(Guid id);

    Response<List<NoteResponseDto>> TGetAll(Expression<Func<Note, bool>>? predicate = null, Func<IQueryable<Note>, IIncludableQueryable<Note, object>>? include = null);
    Response<NoteResponseDto> TGetById(Guid id, Func<IQueryable<Note>, IIncludableQueryable<Note, object>>? include = null);
    Response<NoteResponseDto> TGetByFilter(Expression<Func<Note, bool>> predicate, Func<IQueryable<Note>, IIncludableQueryable<Note, object>>? include = null);

    Response<List<NoteResponseDto>> TGetBookNotesWithPrivacyLevel(Guid bookId);
}
