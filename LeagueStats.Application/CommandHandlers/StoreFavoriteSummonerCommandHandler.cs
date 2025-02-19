using LeagueStats.Application.Commands;
using LeagueStats.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Application.CommandHandlers
{
    public class StoreFavoriteSummonerCommandHandler : IRequestHandler<StoreFavoriteSummonerCommand, bool>
    {
        private readonly ISummonersRepository _repository;

        public StoreFavoriteSummonerCommandHandler(ISummonersRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(StoreFavoriteSummonerCommand request, CancellationToken cancellationToken)
        {
            _repository.AddSummonerToFavorites(request.Summoner);

            return await _repository.UnitOfWork.Commit();
        }
    }
}
