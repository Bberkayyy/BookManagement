using Core.Persistence.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete;

public class BookRepository : EfRepositoryBase<BaseDbContext, Book, Guid>, IBookRepository
{
    public BookRepository(BaseDbContext context) : base(context)
    {
    }

    public List<Book> SearchBooks(string? name, string? categoryName, string? authorName, string? shelfCode)
    {
        IQueryable<Book> query = Context.Books
       .Include(b => b.Category)
       .Include(b => b.Author)
       .Include(b => b.Shelf)
       .AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(b => b.Name.Contains(name));
        }

        if (!string.IsNullOrWhiteSpace(categoryName))
        {
            query = query.Where(b => b.Category.Name.Contains(categoryName));
        }

        if (!string.IsNullOrWhiteSpace(authorName))
        {
            query = query.Where(b => b.Author.FirstName.Contains(authorName));
        }

        if (!string.IsNullOrWhiteSpace(shelfCode))
        {
            query = query.Where(b => b.Shelf.ShelfCode.Contains(shelfCode));
        }

        return query.ToList();
    }
}
