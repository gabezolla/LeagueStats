using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Infrastructure.Models
{
    public class MatchStatsDTO : RiotDTO
    {
        public Info Info { get; set; }
        
    }

    public class Info
    {
        public IEnumerable<ParticipantStats> Participants { get; set; }
    }
}
