using Core.Persistence.EntityBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities;

public class Note : Entity<Guid>
{
    public Guid BookId { get; set; }
    public Guid AppUserId { get; set; }
    public string Content { get; set; }
    public bool IsPrivate { get; set; }

    public Book Book { get; set; }
    public AppUser AppUser { get; set; }

    public NoteShare NoteShare { get; set; }
}
