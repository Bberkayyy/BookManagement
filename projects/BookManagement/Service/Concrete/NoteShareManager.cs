using Core.Shared;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using Models.Dtos.RequestDtos.NoteShareRequestDtos;
using Models.Dtos.ResponseDtos.NoteShareResponseDtos;
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

public class NoteShareManager : INoteShareService
{
    private readonly INoteShareRepository _noteShareRepository;
    private readonly INoteShareRules _noteShareRules;

    public NoteShareManager(INoteShareRepository NoteShareRepository, INoteShareRules noteShareRules)
    {
        _noteShareRepository = NoteShareRepository;
        _noteShareRules = noteShareRules;
    }

    public Response<NoteShareResponseDto> TAdd(NoteShareAddRequestDto addRequestDto)
    {
        _noteShareRules.NoteIsExists(addRequestDto.NoteId);
        NoteShare noteShare = NoteShareAddRequestDto.ConvertToEntity(addRequestDto);
        _noteShareRepository.Add(noteShare);
        NoteShareResponseDto response = NoteShareResponseDto.ConvertToResponse(noteShare);
        return new Response<NoteShareResponseDto>()
        {
            Data = response,
            Message = "NoteShare created successfully!",
            StatusCode = System.Net.HttpStatusCode.Created,
        };
    }

    public Response<NoteShareResponseDto> TDelete(Guid id)
    {
        _noteShareRules.NoteShareIsExists(id);
        NoteShare? noteShare = _noteShareRepository.GetById(id);
        _noteShareRepository.Delete(noteShare);
        return new Response<NoteShareResponseDto>()
        {
            Message = "NoteShare deleted successfully!",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<NoteShareResponseDto>> TGetAll(Expression<Func<NoteShare, bool>>? predicate = null, Func<IQueryable<NoteShare>, IIncludableQueryable<NoteShare, object>>? include = null)
    {
        List<NoteShare> noteShare = _noteShareRepository.GetAll(predicate, include);
        List<NoteShareResponseDto> response = noteShare.Select(x => NoteShareResponseDto.ConvertToResponse(x)).ToList();
        return new Response<List<NoteShareResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<NoteShareResponseDto> TGetByFilter(Expression<Func<NoteShare, bool>> predicate, Func<IQueryable<NoteShare>, IIncludableQueryable<NoteShare, object>>? include = null)
    {
        NoteShare? noteShare = _noteShareRepository.GetByFilter(predicate, include);
        NoteShareResponseDto response = NoteShareResponseDto.ConvertToResponse(noteShare);
        return new Response<NoteShareResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<NoteShareResponseDto> TGetById(Guid id, Func<IQueryable<NoteShare>, IIncludableQueryable<NoteShare, object>>? include = null)
    {
        _noteShareRules.NoteShareIsExists(id);
        NoteShare? noteShare = _noteShareRepository.GetById(id, include);
        NoteShareResponseDto response = NoteShareResponseDto.ConvertToResponse(noteShare);
        return new Response<NoteShareResponseDto>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<NoteShareResponseDto> TUpdate(NoteShareUpdateRequestDto updateRequestDto)
    {
        _noteShareRules.NoteIsExists(updateRequestDto.NoteId);
        NoteShare noteShare = NoteShareUpdateRequestDto.ConvertToEntity(updateRequestDto);
        _noteShareRepository.Update(noteShare);
        NoteShareResponseDto response = NoteShareResponseDto.ConvertToResponse(noteShare);
        return new Response<NoteShareResponseDto>()
        {
            Data = response,
            Message = "NoteShare updated successfully!",
            StatusCode = System.Net.HttpStatusCode.OK,
        };
    }
}
