﻿using Core.Shared;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.CategoryRequestDtos;
using Models.Dtos.ResponseDtos.BookResponseDtos;
using Models.Dtos.ResponseDtos.CategoryResponseDtos;
using Models.Entities;
using Service.Abstract;
using Service.ServiceRules.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryRules _categoryRules;

    public CategoryManager(ICategoryRepository categoryRepository, ICategoryRules categoryRules)
    {
        _categoryRepository = categoryRepository;
        _categoryRules = categoryRules;
    }

    public Response<List<BookResponseWithRelationshipsDto>> TGetCategoryBooks(Guid categoryId)
    {
        _categoryRules.CategoryIsExists(categoryId);
        List<Book> books = _categoryRepository.GetCategoryBooks(categoryId);
        List<BookResponseWithRelationshipsDto> response = books.Select(x => BookResponseWithRelationshipsDto.ConvertToResponse(x)).ToList();
        return new Response<List<BookResponseWithRelationshipsDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<CategoryResponseDto> TAdd(CategoryAddRequestDto addRequestDto)
    {
        _categoryRules.CategoryNameMustBeUnique(addRequestDto.Name);
        _categoryRules.CategoryNameCanNotBeNullOrWhiteSpace(addRequestDto.Name);
        _categoryRules.CategoryNameMustBeAtLeast3Characters(addRequestDto.Name);
        Category category = CategoryAddRequestDto.ConvertToEntity(addRequestDto);
        _categoryRepository.Add(category);
        CategoryResponseDto response = CategoryResponseDto.ConvertToResponse(category);
        return new Response<CategoryResponseDto>()
        {
            Data = response,
            Message = "Category created successfully!",
            StatusCode = System.Net.HttpStatusCode.Created,
        };

    }

    public Response<CategoryResponseDto> TDelete(Guid Id)
    {
        _categoryRules.CategoryIsExists(Id);
        Category? category = _categoryRepository.GetById(Id);
        _categoryRepository.Delete(category);
        return new Response<CategoryResponseDto>()
        {
            Message = "Category deleted successfully!",
            StatusCode = System.Net.HttpStatusCode.OK
        };

    }

    public Response<List<CategoryResponseDto>> TGetAll(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
    {
        List<Category> categories = _categoryRepository.GetAll(predicate, include);
        List<CategoryResponseDto> response = categories.Select(x => CategoryResponseDto.ConvertToResponse(x)).ToList();
        return new Response<List<CategoryResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<CategoryResponseDto> TGetByFilter(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
    {
        Category? category = _categoryRepository.GetByFilter(predicate, include);
        CategoryResponseDto response = CategoryResponseDto.ConvertToResponse(category);
        return new Response<CategoryResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<CategoryResponseDto> TGetById(Guid id, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
    {
        _categoryRules.CategoryIsExists(id);
        Category? category = _categoryRepository.GetById(id, include);
        CategoryResponseDto response = CategoryResponseDto.ConvertToResponse(category);
        return new Response<CategoryResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<CategoryResponseDto> TUpdate(CategoryUpdateRequestDto updateRequestDto)
    {
        _categoryRules.CategoryIsExists(updateRequestDto.Id);
        _categoryRules.CategoryNameMustBeUnique(updateRequestDto.Name);
        _categoryRules.CategoryNameMustBeAtLeast3Characters(updateRequestDto.Name);
        _categoryRules.CategoryNameCanNotBeNullOrWhiteSpace(updateRequestDto.Name);
        Category category = CategoryUpdateRequestDto.ConvertToEntity(updateRequestDto);
        _categoryRepository.Update(category);
        CategoryResponseDto response = CategoryResponseDto.ConvertToResponse(category);
        return new Response<CategoryResponseDto>()
        {
            Data = response,
            Message = "Category updated successfully!",
            StatusCode = System.Net.HttpStatusCode.OK,
        };
    }
}
