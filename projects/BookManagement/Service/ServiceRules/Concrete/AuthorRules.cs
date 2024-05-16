using Core.CrossCuttingConcerns;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Models.Entities;
using Service.ServiceRules.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Concrete;

public class AuthorRules : IAuthorRules
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorRules(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public void AuthorCountryCanNotBeNullOrWhiteSpace(string country)
    {
        if (string.IsNullOrWhiteSpace(country))
            throw new BusinessException("Please enter a country name!");
    }

    public void AuthorFirstAndLastNameCanNotBeNullOrWhiteSpace(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new BusinessException("Author first and last name can not be empty!");
    }

    public void AuthorFirstAndLastNameMustBeAtLeast3Characters(string firstName, string lastName)
    {
        if (firstName.Length < 3 || firstName.Length < 3)
            throw new BusinessException($"Author first and last name must be at least 3 characters!");
    }

    public void AuthorFirstNameMustBeUnique(string firstName)
    {
        Author? author = _authorRepository.GetByFilter(x => x.FirstName == firstName);
        if (author != null)
            throw new BusinessException($"Author name is already exists ({firstName}). Please enter a diffrent author name.");
    }

    public void AuthorIsExists(Guid id)
    {
        Author? author = _authorRepository.GetById(id);
        if (author == null)
            throw new BusinessException($"Author does not exists!");
    }
}
