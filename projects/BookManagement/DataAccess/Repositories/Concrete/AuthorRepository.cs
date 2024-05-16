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

public class AuthorRepository : EfRepositoryBase<BaseDbContext, Author, Guid>, IAuthorRepository
{
    public AuthorRepository(BaseDbContext context) : base(context)
    {
    }

    public List<Book> GetAuthorBooks(Guid authorId)
    {
        return Context.Books.Where(x => x.AuthorId == authorId).Include(x => x.Category).Include(x => x.Author).ToList();
    }
}
