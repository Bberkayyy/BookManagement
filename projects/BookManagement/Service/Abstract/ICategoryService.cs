using Core.Shared;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.CategoryRequestDtos;
using Models.Dtos.ResponseDtos.BookResponseDtos;
using Models.Dtos.ResponseDtos.CategoryResponseDtos;
using Models.Entities;
using System.Linq.Expressions;

namespace Service.Abstract;

public interface ICategoryService
{
    Response<CategoryResponseDto> TAdd(CategoryAddRequestDto addRequestDto);
    Response<CategoryResponseDto> TUpdate(CategoryUpdateRequestDto updateRequestDto);
    Response<CategoryResponseDto> TDelete(Guid Id);

    Response<List<CategoryResponseDto>> TGetAll(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null);
    Response<CategoryResponseDto> TGetById(Guid id, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null);
    Response<CategoryResponseDto> TGetByFilter(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null);

    Response<List<BookResponseWithRelationshipsDto>> TGetCategoryBooks(Guid categoryId);
}
