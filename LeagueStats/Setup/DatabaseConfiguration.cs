using LeagueStats.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace LeagueStats.Setup
{
    public static class DatabaseConfiguration
    {
        public static WebApplicationBuilder ConfigureEntityFramework(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("Database");

            builder.Services.AddDbContext<LeagueStatsDbContext>(options => options.UseMySQL(connectionString));

            return builder;
        }
    }
}
