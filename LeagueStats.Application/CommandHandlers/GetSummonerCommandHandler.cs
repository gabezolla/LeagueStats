using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetSummonerCommandHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<Summoner> Handle(GetSummonerCommand request, CancellationToken cancellationToken)
        {
            var result = await _accountService.GetSummoner(request.GameName, request.TagLine);  
            
            return _mapper.Map<Summoner>(result);
        }
    }
}
