using Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDtos.CategoryRequestDtos;
using Models.Dtos.ResponseDtos.BookResponseDtos;
using Models.Dtos.ResponseDtos.CategoryResponseDtos;
using Service.Abstract;

namespace WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        Response<List<CategoryResponseDto>> result = _categoryService.TGetAll();
        return ActionResultInstance(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        Response<CategoryResponseDto> result = _categoryService.TGetById(id);
        return ActionResultInstance(result);
    }
    [HttpPost]
    public IActionResult Create(CategoryAddRequestDto addRequestDto)
    {
        Response<CategoryResponseDto> result = _categoryService.TAdd(addRequestDto);
        return ActionResultInstance(result);
    }
    [HttpPut]
    public IActionResult Update(CategoryUpdateRequestDto updateRequestDto)
    {
        Response<CategoryResponseDto> result = _categoryService.TUpdate(updateRequestDto);
        return ActionResultInstance(result);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        Response<CategoryResponseDto> result = _categoryService.TDelete(id);
        return ActionResultInstance(result);
    }
    [HttpGet("{id}/books")]
    public IActionResult GetCategoryBooks(Guid id)
    {
        Response<List<BookResponseDto>> result = _categoryService.GetCategoryBooks(id);
        return ActionResultInstance(result);
    }
}
