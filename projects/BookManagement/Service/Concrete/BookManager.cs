using Core.Shared;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.BookRequestDtos;
using Models.Dtos.RequestDtos.BookRequestDtos;
using Models.Dtos.ResponseDtos.BookResponseDtos;
using Models.Dtos.ResponseDtos.BookResponseDtos;
using Models.Entities;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete;

public class BookManager : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookManager(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public Response<BookResponseDto> TAdd(BookAddRequestDto addRequestDto)
    {
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

    public Response<BookResponseDto> TDelete(Guid Id)
    {
        Book? book = _bookRepository.GetById(Id);
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
        Book? book = _bookRepository.GetById(id, include);
        BookResponseDto response = BookResponseDto.ConvertToResponse(book);
        return new Response<BookResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<BookResponseDto> TUpdate(BookUpdateRequestDto updateRequestDto)
    {
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
