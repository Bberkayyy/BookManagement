using Core.Shared;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.BookRequestDtos;
using Models.Dtos.ResponseDtos.BookResponseDtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract;

public interface IBookService
{
    Response<BookResponseDto> TAdd(BookAddRequestDto addRequestDto);
    Response<BookResponseDto> TUpdate(BookUpdateRequestDto updateRequestDto);
    Response<BookResponseDto> TDelete(Guid Id);

    Response<List<BookResponseDto>> TGetAll(Expression<Func<Book, bool>>? predicate = null, Func<IQueryable<Book>, IIncludableQueryable<Book, object>>? include = null);
    Response<BookResponseDto> TGetById(Guid id, Func<IQueryable<Book>, IIncludableQueryable<Book, object>>? include = null);
    Response<BookResponseDto> TGetByFilter(Expression<Func<Book, bool>> predicate, Func<IQueryable<Book>, IIncludableQueryable<Book, object>>? include = null);
}
