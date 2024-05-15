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

public class AuthorRepository : EfRepositoryBase<BaseDbContext, Author, Guid>, IAuthorRepository
{
    public AuthorRepository(BaseDbContext context) : base(context)
    {
    }
}
