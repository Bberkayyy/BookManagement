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

public class BookRules : IBookRules
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly ICategoryRepository _categoryRepository;

    public BookRules(IBookRepository bookRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _categoryRepository = categoryRepository;
    }

    public void AuthorIsExists(Guid authorId)
    {
        Author? author = _authorRepository.GetById(authorId);
        if (author == null)
            throw new BusinessException("Author does not exists!");
    }

    public void BookDescriptionCanNotBeNullOrWhiteSpace(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new BusinessException("Please enter a book description!");
    }

    public void BookIsExists(Guid id)
    {
        Book? book = _bookRepository.GetById(id);
        if (book == null)
            throw new BusinessException("Book does not exists!");
    }

    public void BookNameCanNotBeNullOrWhiteSpace(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new BusinessException("Please enter a book name!");
    }

    public void BookNameMustBeUnique(string name)
    {
        Book? book = _bookRepository.GetByFilter(x => x.Name == name);
        if (book != null)
            throw new BusinessException($"Book name is already exists ({name}). Please enter a diffrent book name.");
    }

    public void BookPriceCanNotBeNegative(decimal price)
    {
        if (price < 0)
            throw new BusinessException("Book price can not be negative!");
    }

    public void BookStockCanNotBeNegative(int stock)
    {
        if (stock < 0)
            throw new BusinessException("Book stock can not be negative!");
    }

    public void CategoryIsExists(Guid categoryId)
    {
        Category? category = _categoryRepository.GetById(categoryId);
        if (category == null)
            throw new BusinessException("Category does not exists!");
    }
}
