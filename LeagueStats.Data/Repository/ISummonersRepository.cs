using LeagueStats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Data.Repository
{
    internal interface ISummonersRepository
    {
        public Summoner GetSummonerByPuuid(string puuid);
        
        public Summoner GetSummonerByNameAndTag(string gameName, string tagLine);

        public Task<bool> AddSummonerToFavorites(Summoner summoner);
    }
}
