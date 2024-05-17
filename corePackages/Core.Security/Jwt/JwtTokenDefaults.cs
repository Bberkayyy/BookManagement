using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Jwt;

public class JwtTokenDefaults
{
    public const string ValidAudience = "https://localhost";
    public const string ValidIssuer = "https://localhost";
    public const string Key = "BookManagement/*-+010203ManagementBOOK.,/*-ChallengeProcenne";
    public const int ExpireTime = 3;    
}
