using Core.Persistence.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete;

public class CategoryRepository : EfRepositoryBase<BaseDbContext, Category, Guid>, ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {
    }

    public List<Book> GetCategoryBooks(Guid categoryId)
    {
        return Context.Books.Where(x => x.CategoryId == categoryId).Include(x => x.Author).Include(x => x.Category).ToList();
    }
}