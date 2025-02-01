using LeagueStats.Application.CommandHandlers;
using LeagueStats.Infrastructure.Mappings;
using System.Runtime.CompilerServices;

namespace LeagueStats.Setup
{
    public static class DependenciesCollection
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddMediatr();

            return services;
        }
        private static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AccountDtoToSummonerMappingProfile));
            services.AddAutoMapper(typeof(ParticipantsStatsToStatsMappingProfile));

            return services;
        }

        private static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetSummonerCommandHandler).Assembly));

            return services;
        }
    }
}
