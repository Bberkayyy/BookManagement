using Core.Persistence.EntityBaseModel;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities;

public class NoteShare : Entity<Guid>
{
    public Guid NoteId { get; set; }
    public PrivacyLevel PrivacyLevel { get; set; }

    public Note Note { get; set; }
}
