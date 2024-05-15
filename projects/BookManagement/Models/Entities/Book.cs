using Core.Persistence.EntityBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities;

public class Book : Entity<Guid>
{
    public Guid CategoryId { get; set; }
    public Guid AuthorId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Category Category { get; set; }
    public Author Author { get; set; }
}
