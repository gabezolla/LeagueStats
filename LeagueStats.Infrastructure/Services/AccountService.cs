using AutoMapper;
using LeagueStats.Domain.Entities;
using LeagueStats.Infrastructure.Clients;
using LeagueStats.Infrastructure.Configurations;
using LeagueStats.Infrastructure.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRiotClient _riotClient;
        private readonly AccountServiceConfiguration _config;
        
        public AccountService(IRiotClient riotClient, IOptions<AccountServiceConfiguration> configuration, IMapper mapper)
        {
            _riotClient = riotClient;
            _config = configuration.Value;
        }

        public async Task<AccountDTO> GetSummoner(string gameName, string tagLine)
        {
            var endpoint = _config.Endpoint
                .Replace("{gameName}", gameName)
                .Replace("{tagLine}", tagLine);

            var response = await _riotClient.Get<AccountDTO>(endpoint);

            return response;
        }

        public Task<AccountDTO> GetSummonerById(string puuid)
        {
            throw new NotImplementedException();
        }
    }
}
