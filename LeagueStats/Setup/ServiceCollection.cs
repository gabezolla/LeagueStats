using LeagueStats.Configurations;
using LeagueStats.Infrastructure.Clients;
using LeagueStats.Infrastructure.Models;
using LeagueStats.Infrastructure.Services;
using Microsoft.Extensions.Configuration;

namespace LeagueStats.Setup
{
    public static class ServiceCollection
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            return services.AddScoped<IAccountService, AccountService>();            
        }

        public static WebApplicationBuilder RegisterHttpClients(this WebApplicationBuilder builder)
        {
            var config = builder.Configuration.GetSection("RiotClient").Get<RiotClientConfig>();

            builder.Services.AddHttpClient<IRiotClient<RiotDTO>, RiotClient<RiotDTO>>().ConfigureHttpClient(o =>
            {
                o.BaseAddress = new Uri(config.BaseUrl);
                o.DefaultRequestHeaders.Add("X-Riot-Token", config.ApiKey);
            });

            return builder;
        }
    }
}
