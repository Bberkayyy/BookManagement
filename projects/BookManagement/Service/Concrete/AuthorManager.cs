using Core.Shared;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.AuthorRequestDtos;
using Models.Dtos.ResponseDtos.AuthorResponseDtos;
using Models.Entities;
using Service.Abstract;
using System.Linq.Expressions;

namespace Service.Concrete;

public class AuthorManager : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorManager(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public Response<AuthorResponseDto> TAdd(AuthorAddRequestDto addRequestDto)
    {
        Author author = AuthorAddRequestDto.ConvertToEntity(addRequestDto);
        _authorRepository.Add(author);
        AuthorResponseDto response = AuthorResponseDto.ConvertToResponse(author);
        return new Response<AuthorResponseDto>()
        {
            Data = response,
            Message = "Author created successfully!",
            StatusCode = System.Net.HttpStatusCode.Created,
        };
    }

    public Response<AuthorResponseDto> TDelete(Guid Id)
    {
        Author? author = _authorRepository.GetById(Id);
        _authorRepository.Delete(author);
        return new Response<AuthorResponseDto>()
        {
            Message = "Author deleted successfully!",
            StatusCode = System.Net.HttpStatusCode.OK
        };

    }

    public Response<List<AuthorResponseDto>> TGetAll(Expression<Func<Author, bool>>? predicate = null, Func<IQueryable<Author>, IIncludableQueryable<Author, object>>? include = null)
    {
        List<Author> authors = _authorRepository.GetAll(predicate, include);
        List<AuthorResponseDto> response = authors.Select(x => AuthorResponseDto.ConvertToResponse(x)).ToList();
        return new Response<List<AuthorResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<AuthorResponseDto> TGetByFilter(Expression<Func<Author, bool>> predicate, Func<IQueryable<Author>, IIncludableQueryable<Author, object>>? include = null)
    {
        Author? author = _authorRepository.GetByFilter(predicate, include);
        AuthorResponseDto response = AuthorResponseDto.ConvertToResponse(author);
        return new Response<AuthorResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<AuthorResponseDto> TGetById(Guid id, Func<IQueryable<Author>, IIncludableQueryable<Author, object>>? include = null)
    {
        Author? author = _authorRepository.GetById(id, include);
        AuthorResponseDto response = AuthorResponseDto.ConvertToResponse(author);
        return new Response<AuthorResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<AuthorResponseDto> TUpdate(AuthorUpdateRequestDto updateRequestDto)
    {
        Author author = AuthorUpdateRequestDto.ConvertToEntity(updateRequestDto);
        _authorRepository.Update(author);
        AuthorResponseDto response = AuthorResponseDto.ConvertToResponse(author);
        return new Response<AuthorResponseDto>()
        {
            Data = response,
            Message = "Author updated successfully!",
            StatusCode = System.Net.HttpStatusCode.OK,
        };
    }
}
