using LeagueStats.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace LeagueStats.Setup
{
    public class JwtOptionsSetup : IConfigureOptions<JwtSettings>
    {
        private const string SectionName = "JwtSettings";
        private readonly IConfiguration _configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtSettings settings)
        {
            _configuration.GetSection(SectionName).Bind(settings);
        }
    }
}
