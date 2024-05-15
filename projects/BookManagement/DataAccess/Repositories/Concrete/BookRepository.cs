using Core.Persistence.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
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
}
