﻿using Core.Persistence.Repositories;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract;

public interface INoteShareRepository : IEntityRepository<NoteShare, Guid>, IAsyncEntityRepository<NoteShare, Guid>
{
}
