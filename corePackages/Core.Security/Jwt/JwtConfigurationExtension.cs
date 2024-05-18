using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Jwt;

public static class JwtConfigurationExtension
{
    public static IServiceCollection AddJwtConfiguration(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.TokenValidationParameters = new()
            {
                ValidAudience = JwtTokenDefaults.ValidAudience,
                ValidIssuer = JwtTokenDefaults.ValidIssuer,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
            };
        });
        return services;
    }
}
