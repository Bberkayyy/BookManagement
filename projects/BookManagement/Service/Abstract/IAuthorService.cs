using Core.Shared;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.AuthorRequestDtos;
using Models.Dtos.ResponseDtos.AuthorResponseDtos;
using Models.Dtos.ResponseDtos.BookResponseDtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract;

public interface IAuthorService
{
    Response<AuthorResponseDto> TAdd(AuthorAddRequestDto addRequestDto);
    Response<AuthorResponseDto> TUpdate(AuthorUpdateRequestDto updateRequestDto);
    Response<AuthorResponseDto> TDelete(Guid id);

    Response<List<AuthorResponseDto>> TGetAll(Expression<Func<Author, bool>>? predicate = null, Func<IQueryable<Author>, IIncludableQueryable<Author, object>>? include = null);
    Response<AuthorResponseDto> TGetById(Guid id, Func<IQueryable<Author>, IIncludableQueryable<Author, object>>? include = null);
    Response<AuthorResponseDto> TGetByFilter(Expression<Func<Author, bool>> predicate, Func<IQueryable<Author>, IIncludableQueryable<Author, object>>? include = null);

    Response<List<BookResponseWithRelationshipsDto>> TGetAuthorBooks(Guid authorId);
}
