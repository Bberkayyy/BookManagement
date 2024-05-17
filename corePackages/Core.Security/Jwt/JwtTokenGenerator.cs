using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Jwt;

public class JwtTokenGenerator
{
    public static TokenResponseDto GenerateToken(GetCheckAppUser appUser)
    {
        List<Claim> claims = new();
        if (appUser.Roles != null)
            appUser.Roles.ToList().ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x)));
        claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id));

        if (!string.IsNullOrWhiteSpace(appUser.Username))
            claims.Add(new Claim("Username", appUser.Username));

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
        DateTime expireDate = DateTime.Now.AddHours(JwtTokenDefaults.ExpireTime);

        JwtSecurityToken token = new(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.Now, expires: expireDate, signingCredentials: credentials);

        JwtSecurityTokenHandler handler = new();
        return new TokenResponseDto(handler.WriteToken(token), expireDate);
    }
}
