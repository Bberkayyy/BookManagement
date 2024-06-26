﻿using Core.Persistence.EntityBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities;

public class Author : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }

    public List<Book> Books { get; set; }
}
