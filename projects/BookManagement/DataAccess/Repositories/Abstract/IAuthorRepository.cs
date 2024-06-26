﻿using Core.Persistence.Repositories;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract;

public interface IAuthorRepository : IEntityRepository<Author, Guid>, IAsyncEntityRepository<Author, Guid>
{
    List<Book> GetAuthorBooks(Guid authorId);
}
