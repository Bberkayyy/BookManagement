using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Jwt;

public class GetCheckAppUser
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string[] Roles { get; set; }
    public bool IsExists { get; set; }
}
