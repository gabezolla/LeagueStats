using LeagueStats.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Application.Commands
{
    public class GetStoredStatsFromPlayerCommand : IRequest<IEnumerable<Stats>>
    {
        public GetStoredStatsFromPlayerCommand(string playerId)
        {
            PlayerId = playerId;
        }

        public string PlayerId { get; set; }
    }
}
