using AutoMapper;
using LeagueStats.Application.Abstractions;
using LeagueStats.Application.Commands;
using LeagueStats.Domain.Entities;
using MediatR;

namespace LeagueStats.Application.CommandHandlers
{
    public class GetMatchStatsCommandHandler : IRequestHandler<GetMatchStatsCommand, IEnumerable<Stats>>
    {
        private readonly IMatchStatsService _matchService;

        public GetMatchStatsCommandHandler(IMatchStatsService matchService)
        {
            _matchService = matchService;
        }

        public async Task<IEnumerable<Stats>> Handle(GetMatchStatsCommand request, CancellationToken cancellationToken)
        {
            var result = await _matchService.GetMatchStats(request.MatchId);

            if (result == null)
            {
                return new List<Stats>();
            }

            return result;
        }
    }
}
