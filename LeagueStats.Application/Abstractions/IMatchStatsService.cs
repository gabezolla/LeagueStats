using LeagueStats.Domain.Entities;

namespace LeagueStats.Application.Abstractions
{
    public interface IMatchStatsService
    {
        Task<IEnumerable<string>> GetMatchesIds(string summonerId, int quantity = 1);

        Task<IEnumerable<Stats>> GetMatchStats(string matchId);
    }
}