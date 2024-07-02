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

public class ShelfRules : IShelfRules
{
    private readonly IBookRepository _bookRepository;
    private readonly IShelfRepository _shelfRepository;

    public ShelfRules(IBookRepository bookRepository, IShelfRepository shelfRepository)
    {
        _bookRepository = bookRepository;
        _shelfRepository = shelfRepository;
    }

    public void BookIsExist(Guid bookId)
    {
        Book? book = _bookRepository.GetById(bookId);
        if (book == null)
            throw new BusinessException("Book does not exists!");
    }
    public void ShelfIsExist(int shelfId)
    {
        Shelf? shelf = _shelfRepository.GetById(shelfId);
        if (shelf == null)
            throw new BusinessException("Shelf does not exists!");
    }

    public void FloorCanNotBeLessThanZero(int floor)
    {
        if (floor < 0)
            throw new BusinessException("Floor can not be negative!");
    }

    public void SectionCanNotBeNullOrWhiteSpace(string section)
    {
        if (string.IsNullOrWhiteSpace(section))
            throw new BusinessException("Please enter a section!");
    }

    public void ShelfCodeCanNotBeNullOrWhiteSpace(string shelfCode)
    {
        if (string.IsNullOrWhiteSpace(shelfCode))
            throw new BusinessException("Please enter a shelf code!");
    }

    public void ShelfCodeMustBe10Character(string shelfCode)
    {
        if (shelfCode.Length != 10)
            throw new BusinessException("Please enter a 10-character shelf code!");
    }

    public void ShelfCodeMustBeUnique(string shelfCode)
    {
        Shelf? shelf = _shelfRepository.GetByFilter(x => x.ShelfCode == shelfCode);
        if (shelf != null)
            throw new BusinessException($"Shelf code is already exists ({shelfCode}). Please enter a diffrent shelf code.");
    }

    public void ShelfCodeMustContainUpperCaseLetter(string shelfCode)
    {
        if (!shelfCode.Any(char.IsUpper))
            throw new BusinessException("Shelf code msut contain at least one uppercase letter!");
    }
}
