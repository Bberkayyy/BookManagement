using Core.Persistence.EntityBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities;

public class AppRole : Entity<int>
{
    public string Name { get; set; }

    public List<AppUserRole> AppUserRoles { get; set; }
}
