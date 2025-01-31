using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Infrastructure.Models
{
    public class AccountDTO : RiotDTO
    {
        public string Puuid { get; set; }

        public string GameName { get; set; }

        public string TagLine { get; set; }
    }
}
