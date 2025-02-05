using LeagueStats.Domain.Core.Data;
using LeagueStats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Data.Repository
{
    public interface IMatchStatsRepository : IRepository<Stats>
    {
        public Task<IEnumerable<Stats>> GetStatsFromMatchById(string matchId);

        public Task<IEnumerable<Stats>> GetPlayerStatsBySummonerId(string summonerId);

        public void SaveMatchStats(IEnumerable<Stats> stats);
    }
}
