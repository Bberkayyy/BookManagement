using Core.Shared;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDtos.NoteShareRequestDtos;
using Models.Dtos.ResponseDtos.NoteShareResponseDtos;
using Service.Abstract;

namespace WebApi.Controllers
{
    [Route("api/noteshares")]
    [ApiController]
    public class NoteSharesController : BaseController
    {
        private readonly INoteShareService _noteShareService;

        public NoteSharesController(INoteShareService noteShareService)
        {
            _noteShareService = noteShareService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Response<List<NoteShareResponseDto>> result = _noteShareService.TGetAll();
            return ActionResultInstance(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Response<NoteShareResponseDto> result = _noteShareService.TGetById(id);
            return ActionResultInstance(result);
        }
        [HttpPost]
        public IActionResult Create(NoteShareAddRequestDto addRequestDto)
        {
            Response<NoteShareResponseDto> result = _noteShareService.TAdd(addRequestDto);
            return ActionResultInstance(result);
        }
        [HttpPut]
        public IActionResult Update(NoteShareUpdateRequestDto updateRequestDto)
        {
            Response<NoteShareResponseDto> result = _noteShareService.TUpdate(updateRequestDto);
            return ActionResultInstance(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Response<NoteShareResponseDto> result = _noteShareService.TDelete(id);
            return ActionResultInstance(result);
        }
    }
}
