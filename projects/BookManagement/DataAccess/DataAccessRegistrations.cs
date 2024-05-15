using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public static class DataAccessRegistrations
{
    public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        return services;
    }
}
