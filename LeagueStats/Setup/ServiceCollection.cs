using LeagueStats.Infrastructure.Clients;
using LeagueStats.Discord.Facades;
using LeagueStats.Infrastructure.Models;
using LeagueStats.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LeagueStats.Domain.Core.Data;
using LeagueStats.Data.Repository;
using LeagueStats.Application.Abstractions;
using LeagueStats.Domain.Repository;
using LeagueStats.Infrastructure.Authentication;

namespace LeagueStats.Setup
{
    public static class ServiceCollection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services.AddScoped<IAccountService, AccountService>()
                           .AddScoped<IRiotClient, RiotClient>()
                           .AddScoped<IMatchStatsService, MatchStatsService>()
                           .AddSingleton<IDiscordBotFacade, DiscordBotFacade>()
                           .AddScoped<IMatchStatsRepository, MatchStatsRepository>()
                           .AddScoped<ISummonersRepository, SummonersRepository>()
                           .AddScoped<IMembersRepository, MembersRepository>()
                           .AddScoped<IJwtProvider, JwtProvider>();
        }
    }
}
