using Core.Shared;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.AuthorRequestDtos;
using Models.Dtos.ResponseDtos.AuthorResponseDtos;
using Models.Dtos.ResponseDtos.BookResponseDtos;
using Models.Entities;
using Service.Abstract;
using Service.ServiceRules.Abstract;
using System.Linq.Expressions;

namespace Service.Concrete;

public class AuthorManager : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IAuthorRules _authorRules;

    public AuthorManager(IAuthorRepository authorRepository, IAuthorRules authorRules)
    {
        _authorRepository = authorRepository;
        _authorRules = authorRules;
    }

    public Response<List<BookResponseWithRelationshipsDto>> TGetAuthorBooks(Guid authorId)
    {
        _authorRules.AuthorIsExists(authorId);
        List<Book> books = _authorRepository.GetAuthorBooks(authorId);
        List<BookResponseWithRelationshipsDto> response = books.Select(x => BookResponseWithRelationshipsDto.ConvertToResponse(x)).ToList();
        return new Response<List<BookResponseWithRelationshipsDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<AuthorResponseDto> TAdd(AuthorAddRequestDto addRequestDto)
    {
        _authorRules.AuthorFirstNameMustBeUnique(addRequestDto.FirstName);
        _authorRules.AuthorFirstAndLastNameCanNotBeNullOrWhiteSpace(addRequestDto.FirstName, addRequestDto.LastName);
        _authorRules.AuthorFirstAndLastNameMustBeAtLeast3Characters(addRequestDto.FirstName, addRequestDto.LastName);
        _authorRules.AuthorCountryCanNotBeNullOrWhiteSpace(addRequestDto.Country);
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

    public Response<AuthorResponseDto> TDelete(Guid id)
    {
        _authorRules.AuthorIsExists(id);
        Author? author = _authorRepository.GetById(id);
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
        _authorRules.AuthorIsExists(id);
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
        _authorRules.AuthorIsExists(updateRequestDto.Id);
        _authorRules.AuthorFirstNameMustBeUnique(updateRequestDto.FirstName);
        _authorRules.AuthorFirstAndLastNameCanNotBeNullOrWhiteSpace(updateRequestDto.FirstName, updateRequestDto.LastName);
        _authorRules.AuthorFirstAndLastNameMustBeAtLeast3Characters(updateRequestDto.FirstName, updateRequestDto.LastName);
        _authorRules.AuthorCountryCanNotBeNullOrWhiteSpace(updateRequestDto.Country);
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
