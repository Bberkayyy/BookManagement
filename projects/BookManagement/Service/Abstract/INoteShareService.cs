using Core.Shared;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.NoteShareRequestDtos;
using Models.Dtos.ResponseDtos.NoteShareResponseDtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract;

public interface INoteShareService
{
    Response<NoteShareResponseDto> TAdd(NoteShareAddRequestDto addRequestDto);
    Response<NoteShareResponseDto> TUpdate(NoteShareUpdateRequestDto updateRequestDto);
    Response<NoteShareResponseDto> TDelete(Guid id);

    Response<List<NoteShareResponseDto>> TGetAll(Expression<Func<NoteShare, bool>>? predicate = null, Func<IQueryable<NoteShare>, IIncludableQueryable<NoteShare, object>>? include = null);
    Response<NoteShareResponseDto> TGetById(Guid id, Func<IQueryable<NoteShare>, IIncludableQueryable<NoteShare, object>>? include = null);
    Response<NoteShareResponseDto> TGetByFilter(Expression<Func<NoteShare, bool>> predicate, Func<IQueryable<NoteShare>, IIncludableQueryable<NoteShare, object>>? include = null);
}
