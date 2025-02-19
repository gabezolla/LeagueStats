using LeagueStats.Application.Abstractions;
using LeagueStats.Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Application.CommandHandlers
{
    public class GetMatchesIdCommandHandler : IRequestHandler<GetMatchesIdCommand, IEnumerable<string>>
    {
        private readonly IMatchStatsService _matchStatsService;

        public GetMatchesIdCommandHandler(IMatchStatsService matchStatsService)
        {
            _matchStatsService = matchStatsService;
        }

        public async Task<IEnumerable<string>> Handle(GetMatchesIdCommand request, CancellationToken cancellationToken)
        {
            return await _matchStatsService.GetMatchesIds(request.SummonerId, request.Quantity);            
        }
    }
}
