using LeagueStats.Application.Commands;
using LeagueStats.Domain.Entities;
using LeagueStats.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Application.CommandHandlers
{
    public class GetSummonerCommandHandler : IRequestHandler<GetSummonerCommand, Summoner> // TODO: change to SummonerViewModel
    {
        private readonly IAccountService _accountService;

        public GetSummonerCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Summoner> Handle(GetSummonerCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.GetSummoner(request.GameName, request.TagLine);            
        }
    }
}
