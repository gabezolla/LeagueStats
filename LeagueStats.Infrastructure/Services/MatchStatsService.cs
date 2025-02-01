using LeagueStats.Abstractions.Extensions;
using LeagueStats.Infrastructure.Clients;
using LeagueStats.Infrastructure.Configurations;
using LeagueStats.Infrastructure.Models;
using Microsoft.Extensions.Options;

namespace LeagueStats.Infrastructure.Services
{
    public class MatchStatsService : IMatchStatsService
    {
        private readonly IRiotClient _client;
        private readonly MatchStatsServiceConfig _config;

        public MatchStatsService(IRiotClient client, IOptions<MatchStatsServiceConfig> config)
        {
            _client = client;
            _config = config.Value;
        }

        public async Task<MatchStatsDTO> GetMatchStats(string matchId)
        {
            var endpoint = _config.GetMatchStatsEndpoint.Replace("{matchId}", matchId);

            var response = await _client.Get<MatchStatsDTO>(endpoint);

            return response;
        }

        public async Task<IEnumerable<string>> GetMatchesIds(string summonerId, int? quantity = 1)
        {
            var endpoint = $"{_config.GetMatchesIdsEndpoint.Replace("{puuid}", summonerId)}";

            var queryParams = new Dictionary<string, string> { { "count", quantity.ToString() } };

            var uri = endpoint.AddQueryParameters(queryParams);

            var response = await _client.Get<IEnumerable<string>>(uri);

            return response;
        }
    }
}
