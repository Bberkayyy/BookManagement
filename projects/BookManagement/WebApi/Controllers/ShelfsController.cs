using Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDtos.ShelfRequestDtos;
using Models.Dtos.ResponseDtos.ShelfResponseDtos;
using Service.Abstract;

namespace WebApi.Controllers;

[Route("api/shelfs")]
[ApiController]
public class ShelfsController : BaseController
{
    private readonly IShelfService _shelfService;

    public ShelfsController(IShelfService ShelfService)
    {
        _shelfService = ShelfService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        Response<List<ShelfResponseDto>> result = _shelfService.TGetAll();
        return ActionResultInstance(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Response<ShelfResponseDto> result = _shelfService.TGetById(id);
        return ActionResultInstance(result);
    }
    [HttpPost]
    public IActionResult Create(ShelfAddRequestDto addRequestDto)
    {
        Response<ShelfResponseDto> result = _shelfService.TAdd(addRequestDto);
        return ActionResultInstance(result);
    }
    [HttpPut]
    public IActionResult Update(ShelfUpdateRequestDto updateRequestDto)
    {
        Response<ShelfResponseDto> result = _shelfService.TUpdate(updateRequestDto);
        return ActionResultInstance(result);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Response<ShelfResponseDto> result = _shelfService.TDelete(id);
        return ActionResultInstance(result);
    }
}
