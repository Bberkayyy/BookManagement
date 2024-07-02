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

public class NoteRepository : EfRepositoryBase<BaseDbContext, Note, Guid>, INoteRepository
{
    public NoteRepository(BaseDbContext context) : base(context)
    {
    }

    public List<Note> GetBookNotesWithPrivacyLevel(Guid bookId)
    {
        return Context.Notes.Where(x => x.BookId == bookId).Include(x => x.NoteShare).ToList();
    }
}
