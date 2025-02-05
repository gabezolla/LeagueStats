using LeagueStats.Domain.Core.Data;
using LeagueStats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Data.Repository
{
    public class SummonersRepository : ISummonersRepository
    {
        private readonly LeagueStatsDbContext _context;

        public SummonersRepository(LeagueStatsDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void AddSummonerToFavorites(Summoner summoner)
        {
            _context.Summoners.Add(summoner);
        }

        public void Dispose() => _context.Dispose();

        public async Task<Summoner?> GetSummonerByNameAndTag(string gameName, string tagLine)
        {
            var summonersList = await _context.Summoners.ToListAsync();

            return summonersList.FirstOrDefault(s => s.GameName.Equals(gameName) && s.Tagline.Equals(tagLine));
        }

        public async Task<Summoner?> GetSummonerByPuuid(string puuid)
        {
            var summonersList = await _context.Summoners.ToListAsync();

            return summonersList.FirstOrDefault(s => s.Id.Equals(puuid));
        }

        public async Task<IEnumerable<Summoner>> GetFavoriteSummoners()
        {
            var summonersList = await _context.Summoners.ToListAsync();

            return summonersList;
        }
    }
}
