using Core.Shared;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.BookRequestDtos;
using Models.Dtos.ResponseDtos.BookResponseDtos;
using Models.Entities;
using Service.Abstract;
using Service.ServiceRules.Abstract;
using System.Linq.Expressions;

namespace Service.Concrete;

public class BookManager : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookRules _bookRules;

    public BookManager(IBookRepository bookRepository, IBookRules bookRules)
    {
        _bookRepository = bookRepository;
        _bookRules = bookRules;
    }

    public Response<BookResponseDto> TAdd(BookAddRequestDto addRequestDto)
    {
        _bookRules.AuthorIsExists(addRequestDto.AuthorId);
        _bookRules.CategoryIsExists(addRequestDto.CategoryId);
        _bookRules.BookNameMustBeUnique(addRequestDto.Name);
        _bookRules.BookNameCanNotBeNullOrWhiteSpace(addRequestDto.Name);
        _bookRules.BookDescriptionCanNotBeNullOrWhiteSpace(addRequestDto.Description);
        _bookRules.BookPriceCanNotBeNegative(addRequestDto.Price);
        _bookRules.BookStockCanNotBeNegative(addRequestDto.Stock);
        Book book = BookAddRequestDto.ConvertToEntity(addRequestDto);
        _bookRepository.Add(book);
        BookResponseDto response = BookResponseDto.ConvertToResponse(book);
        return new Response<BookResponseDto>()
        {
            Data = response,
            Message = "Book created successfully!",
            StatusCode = System.Net.HttpStatusCode.Created,
        };
    }

    public Response<BookResponseDto> TDelete(Guid id)
    {
        _bookRules.BookIsExists(id);
        Book? book = _bookRepository.GetById(id);
        _bookRepository.Delete(book);
        return new Response<BookResponseDto>()
        {
            Message = "Book deleted successfully!",
            StatusCode = System.Net.HttpStatusCode.OK
        };

    }

    public Response<List<BookResponseDto>> TGetAll(Expression<Func<Book, bool>>? predicate = null, Func<IQueryable<Book>, IIncludableQueryable<Book, object>>? include = null)
    {
        List<Book> books = _bookRepository.GetAll(predicate, include);
        List<BookResponseDto> response = books.Select(x => BookResponseDto.ConvertToResponse(x)).ToList();
        return new Response<List<BookResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<BookResponseWithShelfInfoDto>> TGetBooksWithShelfInfo()
    {
        List<Book> books = _bookRepository.GetAll(include: x => x.Include(x => x.Category).Include(x => x.Author).Include(x => x.Shelf));
        List<BookResponseWithShelfInfoDto> response = books.Select(x => BookResponseWithShelfInfoDto.ConvertToResponse(x)).ToList();
        return new Response<List<BookResponseWithShelfInfoDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<BookResponseDto> TGetByFilter(Expression<Func<Book, bool>> predicate, Func<IQueryable<Book>, IIncludableQueryable<Book, object>>? include = null)
    {
        Book? book = _bookRepository.GetByFilter(predicate, include);
        BookResponseDto response = BookResponseDto.ConvertToResponse(book);
        return new Response<BookResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<BookResponseDto> TGetById(Guid id, Func<IQueryable<Book>, IIncludableQueryable<Book, object>>? include = null)
    {
        _bookRules.BookIsExists(id);
        Book? book = _bookRepository.GetById(id, include);
        BookResponseDto response = BookResponseDto.ConvertToResponse(book);
        return new Response<BookResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<BookResponseForSearchDto>> TSearchBooks(string? name, string? categoryName, string? authorName, string? shelfCode)
    {
        List<Book> books = _bookRepository.SearchBooks(name, categoryName, authorName, shelfCode);
        List<BookResponseForSearchDto> response = books.Select(x => BookResponseForSearchDto.ConvertToResponse(x)).ToList();
        return new Response<List<BookResponseForSearchDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<BookResponseDto> TUpdate(BookUpdateRequestDto updateRequestDto)
    {
        _bookRules.BookIsExists(updateRequestDto.Id);
        _bookRules.AuthorIsExists(updateRequestDto.AuthorId);
        _bookRules.CategoryIsExists(updateRequestDto.CategoryId);
        _bookRules.BookNameMustBeUnique(updateRequestDto.Name);
        _bookRules.BookNameCanNotBeNullOrWhiteSpace(updateRequestDto.Name);
        _bookRules.BookDescriptionCanNotBeNullOrWhiteSpace(updateRequestDto.Description);
        _bookRules.BookPriceCanNotBeNegative(updateRequestDto.Price);
        _bookRules.BookStockCanNotBeNegative(updateRequestDto.Stock);
        Book book = BookUpdateRequestDto.ConvertToEntity(updateRequestDto);
        _bookRepository.Update(book);
        BookResponseDto response = BookResponseDto.ConvertToResponse(book);
        return new Response<BookResponseDto>()
        {
            Data = response,
            Message = "Book updated successfully!",
            StatusCode = System.Net.HttpStatusCode.OK,
        };
    }
}
