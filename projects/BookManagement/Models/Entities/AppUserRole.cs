using Core.Persistence.EntityBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities;

public class AppUserRole : Entity<int>
{
    public Guid AppUserId { get; set; }
    public int AppRoleId { get; set; }
    public AppUser User { get; set; }
    public AppRole Role { get; set; }
}
