using Microsoft.Extensions.DependencyInjection;
using Service.Abstract;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

public static class BusinessRegistrations
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookManager>();
        services.AddScoped<IAuthorService, AuthorManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        return services;
    }
}
