using LeagueStats.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Application.Commands
{
    public class StoreFavoriteSummonerCommand : IRequest<bool>
    {
        public StoreFavoriteSummonerCommand(Summoner summoner)
        {
            Summoner = summoner;
        }

        public Summoner Summoner { get; set; }
    }
}
