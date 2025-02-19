using LeagueStats.Domain.Entities;

namespace LeagueStats.Application.Abstractions
{
    public interface IAccountService
    {
        Task<Summoner> GetSummonerById(string puuid);

        Task<Summoner> GetSummoner(string gameName, string tagLine);
    }
}
