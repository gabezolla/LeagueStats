using LeagueStats.Infrastructure.Models;

namespace LeagueStats.Infrastructure.Services
{
    public interface IMatchStatsService
    {
        Task<IEnumerable<string>> GetMatchesIds(string summonerId, int? quantity = 1);

        Task<MatchStatsDTO> GetMatchStats(string matchId);
    }
}