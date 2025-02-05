using LeagueStats.Application.Commands;
using LeagueStats.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Discord.Facades
{
    public class DiscordBotFacade : IDiscordBotFacade
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DiscordBotFacade> _logger;

        public DiscordBotFacade(ILogger<DiscordBotFacade> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<Stats>> GetStats(string gameName, string tagLine)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                var summoner = await mediator.Send(new GetSummonerCommand(gameName, tagLine));

                var favoriteSummoners = await mediator.Send(new GetFavoriteSummonersCommand());

                var matchId = await mediator.Send(new GetMatchesIdCommand(summoner.Id, 1));

                var stats = await mediator.Send(new GetMatchStatsCommand(matchId.First()));

                if (favoriteSummoners.Contains(summoner))
                {
                    var favoriteSummonersIds = favoriteSummoners.Select(s => s.Id).ToList();

                    var statsToStore = stats.Where(s => favoriteSummonersIds.Contains(s.PlayerId)).ToList();

                    await mediator.Send(new StoreMatchStatsCommand(statsToStore));
                }

                return stats;
            }
        }
    }
}
