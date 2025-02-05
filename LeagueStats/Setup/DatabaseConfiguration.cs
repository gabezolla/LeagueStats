using LeagueStats.Data;
using Microsoft.EntityFrameworkCore;

namespace LeagueStats.Setup
{
    public static class DatabaseConfiguration
    {
        public static WebApplicationBuilder ConfigureEntityFramework(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("Database");

            builder.Services.AddDbContext<LeagueStatsDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            return builder;
        }
    }
}
