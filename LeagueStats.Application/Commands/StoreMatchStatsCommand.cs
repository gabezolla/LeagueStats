using LeagueStats.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Application.Commands
{
    public class StoreMatchStatsCommand : IRequest<bool>
    {
        public StoreMatchStatsCommand(IEnumerable<Stats> stats)
        {
            Stats = stats;
        }

        public IEnumerable<Stats> Stats { get; set; }
    }
}
