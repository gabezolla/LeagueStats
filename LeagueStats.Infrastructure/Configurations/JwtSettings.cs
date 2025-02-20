using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Infrastructure.Configurations
{
    public class JwtSettings
    {
        public string Issuer { get; init; }

        public string Audience { get; init; }

        public string Key { get; init; }
    }
}
