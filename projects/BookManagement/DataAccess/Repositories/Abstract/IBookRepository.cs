﻿using Core.Persistence.Repositories;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract;

public interface IBookRepository : IEntityRepository<Book, Guid>, IAsyncEntityRepository<Book, Guid>
{
    List<Book> SearchBooks(string? name, string? categoryName, string? authorName, string? shelfCode);
}
