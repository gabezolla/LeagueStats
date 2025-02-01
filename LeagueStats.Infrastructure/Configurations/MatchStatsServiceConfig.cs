using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Infrastructure.Configurations
{
    public class MatchStatsServiceConfig
    {
        public string GetMatchStatsEndpoint { get; set; }

        public string GetMatchesIdsEndpoint { get; set; }
    }
}
