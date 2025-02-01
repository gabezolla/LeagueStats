using LeagueStats.Domain.Entities;

namespace LeagueStats.Discord.Facades
{
    public interface IDiscordBotFacade
    {
        public Task<IEnumerable<Stats>> GetStats(string gameName, string tagLine);
    }
}