using LeagueStats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Data.Repository
{
    public class SummonersRepository : ISummonersRepository
    {
        public Task<bool> AddSummonerToFavorites(Summoner summoner)
        {
            throw new NotImplementedException();
        }

        public Summoner GetSummonerByNameAndTag(string gameName, string tagLine)
        {
            throw new NotImplementedException();
        }

        public Summoner GetSummonerByPuuid(string puuid)
        {
            throw new NotImplementedException();
        }
    }
}
