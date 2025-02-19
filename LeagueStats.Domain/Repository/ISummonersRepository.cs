using LeagueStats.Domain.Core.Data;
using LeagueStats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Domain.Repository
{
    public interface ISummonersRepository : IRepository<Summoner>
    {
        public Task<Summoner?> GetSummonerByPuuid(string puuid);

        public Task<Summoner?> GetSummonerByNameAndTag(string gameName, string tagLine);

        public void AddSummonerToFavorites(Summoner summoner);

        public Task<IEnumerable<Summoner>> GetFavoriteSummoners();
    }
}
