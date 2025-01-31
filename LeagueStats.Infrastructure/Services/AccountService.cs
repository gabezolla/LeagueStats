using AutoMapper;
using LeagueStats.Domain.Entities;
using LeagueStats.Infrastructure.Clients;
using LeagueStats.Infrastructure.Configurations;
using LeagueStats.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRiotClient<AccountDTO> _riotClient;
        private readonly AccountServiceConfiguration _config;
        private readonly IMapper _mapper;

        public AccountService(IRiotClient<AccountDTO> riotClient, AccountServiceConfiguration configuration, IMapper mapper)
        {
            _riotClient = riotClient;
            _config = configuration;
            _mapper = mapper;
        }

        public async Task<Summoner> GetSummoner(string gameName, string tagLine)
        {
            var endpoint = _config.Endpoint
                .Replace("{gameName}", gameName)
                .Replace("{tagLine}", tagLine);

            var request = await _riotClient.Get(endpoint);

            return _mapper.Map<Summoner>(request);
        }

        public Task<Summoner> GetSummonerById(string puuid)
        {
            throw new NotImplementedException();
        }
    }
}
