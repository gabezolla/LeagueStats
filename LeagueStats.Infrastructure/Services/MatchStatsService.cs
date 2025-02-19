using AutoMapper;
using LeagueStats.Abstractions.Extensions;
using LeagueStats.Application.Abstractions;
using LeagueStats.Domain.Entities;
using LeagueStats.Infrastructure.Clients;
using LeagueStats.Infrastructure.Configurations;
using LeagueStats.Infrastructure.Models;
using MediatR;
using Microsoft.Extensions.Options;

namespace LeagueStats.Infrastructure.Services
{
    public class MatchStatsService : IMatchStatsService
    {
        private readonly IRiotClient _client;
        private readonly MatchStatsServiceConfig _config;
        private readonly IMapper _mapper;

        public MatchStatsService(IRiotClient client, IOptions<MatchStatsServiceConfig> config, IMapper mapper)
        {
            _client = client;
            _config = config.Value;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Stats>> GetMatchStats(string matchId)
        {
            var endpoint = _config.GetMatchStatsEndpoint.Replace("{matchId}", matchId);

            var response = await _client.Get<MatchStatsDTO>(endpoint);

            foreach (var item in response.Info.Participants)
            {
                item.MatchId = response.Metadata.MatchId;
            }

            return _mapper.Map<IEnumerable<Stats>>(response);
        }

        public async Task<IEnumerable<string>> GetMatchesIds(string summonerId, int quantity = 1)
        {
            var endpoint = $"{_config.GetMatchesIdsEndpoint.Replace("{puuid}", summonerId)}";

            var queryParams = new Dictionary<string, string> { { "count", quantity.ToString() } };

            var uri = endpoint.AddQueryParameters(queryParams);

            var response = await _client.Get<IEnumerable<string>>(uri);

            return response;
        }
    }
}
