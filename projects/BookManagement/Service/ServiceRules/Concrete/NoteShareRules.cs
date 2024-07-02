using Core.CrossCuttingConcerns;
using DataAccess.Repositories.Abstract;
using Models.Entities;
using Service.ServiceRules.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Concrete;

public class NoteShareRules : INoteShareRules
{
    private readonly INoteRepository _noteRepository;
    private readonly INoteShareRepository _noteShareRepository;

    public NoteShareRules(INoteRepository noteRepository, INoteShareRepository noteShareRepository)
    {
        _noteRepository = noteRepository;
        _noteShareRepository = noteShareRepository;
    }
    public void NoteIsExists(Guid noteId)
    {
        Note? note = _noteRepository.GetById(noteId);
        if (note == null)
            throw new BusinessException("Note does not exists!");
    }

    public void NoteShareIsExists(Guid noteShareId)
    {
        NoteShare? noteShare = _noteShareRepository.GetById(noteShareId);
        if (noteShare == null)
            throw new BusinessException("Note share does not exists!");
    }
}
