using Core.CrossCuttingConcerns;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Models.Entities;
using Service.ServiceRules.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Concrete;

public class NoteRules : INoteRules
{
    private readonly IAppUserRepository _userRepository;
    private readonly IBookRepository _bookRepository;
    private readonly INoteRepository _noteRepository;

    public NoteRules(IAppUserRepository userRepository, IBookRepository bookRepository, INoteRepository noteRepository)
    {
        _userRepository = userRepository;
        _bookRepository = bookRepository;
        _noteRepository = noteRepository;
    }

    public void AppUserIsExists(Guid userId)
    {
        AppUser? user = _userRepository.GetById(userId);
        if (user == null)
            throw new BusinessException("User does not exists!");
    }

    public void BookIsExists(Guid bookId)
    {
        Book? book = _bookRepository.GetById(bookId);
        if (book == null)
            throw new BusinessException("Book does not exists!");
    }

    public void ContentCanNotBeNullOrWhiteSpace(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new BusinessException("Please enter a note content!");
    }

    public void NoteIsExists(Guid noteId)
    {
        Note? note = _noteRepository.GetById(noteId);
        if (note == null)
            throw new BusinessException("Note does not exists!");
    }
}
