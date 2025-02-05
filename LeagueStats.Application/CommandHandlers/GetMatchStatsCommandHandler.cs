using AutoMapper;
using LeagueStats.Application.Commands;
using LeagueStats.Domain.Entities;
using LeagueStats.Infrastructure.Clients;
using LeagueStats.Infrastructure.Models;
using LeagueStats.Infrastructure.Services;
using MediatR;

namespace LeagueStats.Application.CommandHandlers
{
    public class GetMatchStatsCommandHandler : IRequestHandler<GetMatchStatsCommand, IEnumerable<Stats>>
    {
        private readonly IMapper _mapper;
        private readonly IMatchStatsService _matchService;

        public GetMatchStatsCommandHandler(IMapper mapper, IMatchStatsService matchService)
        {
            _mapper = mapper;
            _matchService = matchService;
        }

        public async Task<IEnumerable<Stats>> Handle(GetMatchStatsCommand request, CancellationToken cancellationToken)
        {
            var result = await _matchService.GetMatchStats(request.MatchId);

            if (result == null)
            {
                return new List<Stats>();
            }

            foreach (var item in result.Info.Participants)
            {
                item.MatchId = request.MatchId;
            }

            return _mapper.Map<IEnumerable<Stats>>(result.Info.Participants);
        }
    }
}
