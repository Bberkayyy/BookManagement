using Core.Shared;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.ShelfRequestDtos;
using Models.Dtos.ResponseDtos.ShelfResponseDtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract;

public interface IShelfService
{
    Response<ShelfResponseDto> TAdd(ShelfAddRequestDto addRequestDto);
    Response<ShelfResponseDto> TUpdate(ShelfUpdateRequestDto updateRequestDto);
    Response<ShelfResponseDto> TDelete(int id);

    Response<List<ShelfResponseDto>> TGetAll(Expression<Func<Shelf, bool>>? predicate = null, Func<IQueryable<Shelf>, IIncludableQueryable<Shelf, object>>? include = null);
    Response<ShelfResponseDto> TGetById(int id, Func<IQueryable<Shelf>, IIncludableQueryable<Shelf, object>>? include = null);
    Response<ShelfResponseDto> TGetByFilter(Expression<Func<Shelf, bool>> predicate, Func<IQueryable<Shelf>, IIncludableQueryable<Shelf, object>>? include = null);
}
