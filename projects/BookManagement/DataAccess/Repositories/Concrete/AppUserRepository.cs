using Core.Persistence.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete;

public class AppUserRepository : EfRepositoryBase<BaseDbContext, AppUser, Guid>, IAppUserRepository
{
    public AppUserRepository(BaseDbContext context) : base(context)
    {
    }
    public override void Add(AppUser entity)
    {
        base.Add(entity);
        Context.Set<AppUserRole>().Add(new AppUserRole()
        {
            AppUserId = entity.Id,
            AppRoleId = 2
        });
        Context.SaveChanges();
    }
}
