using LeagueStats.Application.Commands;
using LeagueStats.Data.Repository;
using LeagueStats.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Application.CommandHandlers
{
    public class GetStoredStatsFromPlayerCommandHandler : IRequestHandler<GetStoredStatsFromPlayerCommand, IEnumerable<Stats>>
    {
        private readonly IMatchStatsRepository _repository;

        public GetStoredStatsFromPlayerCommandHandler(IMatchStatsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Stats>> Handle(GetStoredStatsFromPlayerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.GetPlayerStatsBySummonerId(request.PlayerId);
        }
    }
}
