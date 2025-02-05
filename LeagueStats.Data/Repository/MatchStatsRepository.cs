using LeagueStats.Domain.Core.Data;
using LeagueStats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Data.Repository
{
    public class MatchStatsRepository : IMatchStatsRepository
    {
        private readonly LeagueStatsDbContext _context;

        public MatchStatsRepository(LeagueStatsDbContext context)
        {
            _context = context;            
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose() => _context.Dispose();

        public async Task<IEnumerable<Stats>> GetPlayerStatsBySummonerId(string summonerId)
        {
            var statsList = await _context.Stats.AsNoTracking().ToListAsync();

            return statsList.Where(s => s.PlayerId.Equals(summonerId));
        }

        public async Task<IEnumerable<Stats>> GetStatsFromMatchById(string matchId)
        {
            var statsList = await _context.Stats.AsNoTracking().ToListAsync();

            return statsList.Where(s => s.Id.Equals(matchId));
        }

        public void SaveMatchStats(IEnumerable<Stats> stats)
        {
            foreach(var item in stats)
            {
                _context.Stats.Add(item);
            }
        }
    }
}
