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

public class CategoryRules : ICategoryRules
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void CategoryIsExists(Guid id)
    {
        Category? category = _categoryRepository.GetById(id);
        if (category == null)
            throw new BusinessException($"Category does not exists!");
    }

    public void CategoryNameCanNotBeNullOrWhiteSpace(string categoryName)
    {
        if (string.IsNullOrWhiteSpace(categoryName))
            throw new BusinessException("Please enter a category name!");
    }

    public void CategoryNameMustBeAtLeast3Characters(string categoryName)
    {
        if (categoryName.Length < 3)
            throw new BusinessException($"Category name must be at least 3 characters! (currently : {categoryName.Length})");
    }

    public void CategoryNameMustBeUnique(string categoryName)
    {
        Category? category = _categoryRepository.GetByFilter(x => x.Name == categoryName);
        if (category != null)
            throw new BusinessException($"Category name is already exists ({categoryName}). Please enter a diffrent category name.");
    }
}
