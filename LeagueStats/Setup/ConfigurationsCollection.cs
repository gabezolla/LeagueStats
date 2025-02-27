﻿using LeagueStats.Discord.Configurations;
using LeagueStats.Infrastructure.Configurations;
using LeagueStats.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueStats.Setup
{
    public static class ConfigurationsCollection
    {
        public static WebApplicationBuilder RegisterConfigurations(this WebApplicationBuilder builder)
        {
            var config = builder.Configuration;

            builder.Services.Configure<AccountServiceConfiguration>(config.GetSection("AccountService"));
            builder.Services.Configure<MatchStatsServiceConfig>(config.GetSection("MatchStatsService"));
            builder.Services.Configure<RiotClientConfig>(config.GetSection("RiotClient"));
            builder.Services.Configure<DiscordBotConfig>(config.GetSection("DiscordBot"));
            builder.Services.Configure<JwtSettings>(config.GetSection("JwtSettings"));

            return builder;
        }
    }
}
