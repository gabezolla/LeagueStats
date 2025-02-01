using LeagueStats.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Application.Commands
{
    public class GetMatchStatsCommand : IRequest<IEnumerable<Stats>>
    {
        public GetMatchStatsCommand(string matchId)
        {
            MatchId = matchId;
        }

        public string MatchId { get; set; }
    }
}
