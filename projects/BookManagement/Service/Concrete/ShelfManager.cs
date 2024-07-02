using Core.Shared;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.CategoryRequestDtos;
using Models.Dtos.RequestDtos.ShelfRequestDtos;
using Models.Dtos.ResponseDtos.CategoryResponseDtos;
using Models.Dtos.ResponseDtos.ShelfResponseDtos;
using Models.Entities;
using Service.Abstract;
using Service.ServiceRules.Abstract;
using System.Linq.Expressions;

namespace Service.Concrete;

public class ShelfManager : IShelfService
{
    private readonly IShelfRepository _shelfRepository;
    private readonly IShelfRules _shelfRules;

    public ShelfManager(IShelfRepository shelfRepository, IShelfRules shelfRules)
    {
        _shelfRepository = shelfRepository;
        _shelfRules = shelfRules;
    }

    public Response<ShelfResponseDto> TAdd(ShelfAddRequestDto addRequestDto)
    {
        _shelfRules.BookIsExist(addRequestDto.BookId);
        _shelfRules.FloorCanNotBeLessThanZero(addRequestDto.Floor);
        _shelfRules.SectionCanNotBeNullOrWhiteSpace(addRequestDto.Section);
        _shelfRules.ShelfCodeCanNotBeNullOrWhiteSpace(addRequestDto.ShelfCode);
        _shelfRules.ShelfCodeMustBe10Character(addRequestDto.ShelfCode);
        _shelfRules.ShelfCodeMustBeUnique(addRequestDto.ShelfCode);
        _shelfRules.ShelfCodeMustContainUpperCaseLetter(addRequestDto.ShelfCode);
        Shelf shelf = ShelfAddRequestDto.ConvertToEntity(addRequestDto);
        _shelfRepository.Add(shelf);
        ShelfResponseDto resposne = ShelfResponseDto.ConvertToResponse(shelf);
        return new Response<ShelfResponseDto>()
        {
            Data = resposne,
            Message = "Shelf created successfully!",
            StatusCode = System.Net.HttpStatusCode.Created,
        };
    }

    public Response<ShelfResponseDto> TDelete(int id)
    {
        _shelfRules.ShelfIsExist(id);
        Shelf? shelf = _shelfRepository.GetById(id);
        _shelfRepository.Delete(shelf);
        return new Response<ShelfResponseDto>()
        {
            Message = "Shelf deleted successfully!",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<ShelfResponseDto>> TGetAll(Expression<Func<Shelf, bool>>? predicate = null, Func<IQueryable<Shelf>, IIncludableQueryable<Shelf, object>>? include = null)
    {
        List<Shelf> shelfs = _shelfRepository.GetAll(predicate, include);
        List<ShelfResponseDto> response = shelfs.Select(x => ShelfResponseDto.ConvertToResponse(x)).ToList();
        return new Response<List<ShelfResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<ShelfResponseDto> TGetByFilter(Expression<Func<Shelf, bool>> predicate, Func<IQueryable<Shelf>, IIncludableQueryable<Shelf, object>>? include = null)
    {
        Shelf? shelf = _shelfRepository.GetByFilter(predicate, include);
        ShelfResponseDto response = ShelfResponseDto.ConvertToResponse(shelf);
        return new Response<ShelfResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<ShelfResponseDto> TGetById(int id, Func<IQueryable<Shelf>, IIncludableQueryable<Shelf, object>>? include = null)
    {
        _shelfRules.ShelfIsExist(id);
        Shelf? shelf = _shelfRepository.GetById(id, include);
        ShelfResponseDto response = ShelfResponseDto.ConvertToResponse(shelf);
        return new Response<ShelfResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<ShelfResponseDto> TUpdate(ShelfUpdateRequestDto updateRequestDto)
    {
        _shelfRules.BookIsExist(updateRequestDto.BookId);
        _shelfRules.FloorCanNotBeLessThanZero(updateRequestDto.Floor);
        _shelfRules.SectionCanNotBeNullOrWhiteSpace(updateRequestDto.Section);
        _shelfRules.ShelfCodeCanNotBeNullOrWhiteSpace(updateRequestDto.ShelfCode);
        _shelfRules.ShelfCodeMustBe10Character(updateRequestDto.ShelfCode);
        _shelfRules.ShelfCodeMustBeUnique(updateRequestDto.ShelfCode);
        _shelfRules.ShelfCodeMustContainUpperCaseLetter(updateRequestDto.ShelfCode);
        Shelf shelf = ShelfUpdateRequestDto.ConvertToEntity(updateRequestDto);
        _shelfRepository.Update(shelf);
        ShelfResponseDto response = ShelfResponseDto.ConvertToResponse(shelf);
        return new Response<ShelfResponseDto>()
        {
            Data = response,
            Message = "Category updated successfully!",
            StatusCode = System.Net.HttpStatusCode.OK,
        };
    }
}
