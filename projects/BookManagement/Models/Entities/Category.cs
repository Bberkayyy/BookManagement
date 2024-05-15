using Core.Persistence.EntityBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities;

public class Category : Entity<Guid>
{
    public string Name { get; set; }

    public List<Book> Books { get; set; }
}
