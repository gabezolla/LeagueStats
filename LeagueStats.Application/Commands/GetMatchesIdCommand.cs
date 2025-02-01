using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Application.Commands
{
    public class GetMatchesIdCommand : IRequest<IEnumerable<string>>
    {
        public GetMatchesIdCommand(string summonerId, int quantity)
        {
            Quantity = quantity;
            SummonerId = summonerId;
        }

        public string SummonerId { get; set; }

        public int Quantity { get; set; }
    }
}
