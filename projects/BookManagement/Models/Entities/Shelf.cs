using Core.Persistence.EntityBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities;

public class Shelf : Entity<int>
{
    public Guid BookId { get; set; }
    public string ShelfCode { get; set; }
    public string Section { get; set; }
    public int Floor { get; set; }

    public List<Book> Books { get; set; }
}
