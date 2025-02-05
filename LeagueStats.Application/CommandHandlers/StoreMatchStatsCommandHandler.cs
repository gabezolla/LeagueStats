using LeagueStats.Application.Commands;
using LeagueStats.Data.Repository;
using LeagueStats.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Application.CommandHandlers
{
    public class StoreMatchStatsCommandHandler : IRequestHandler<StoreMatchStatsCommand, bool>
    {
        private readonly IMatchStatsRepository _repository;

        public StoreMatchStatsCommandHandler(IMatchStatsRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(StoreMatchStatsCommand request, CancellationToken cancellationToken)
        {
            _repository.SaveMatchStats(request.Stats);

            return _repository.UnitOfWork.Commit();
        }
    }
}
