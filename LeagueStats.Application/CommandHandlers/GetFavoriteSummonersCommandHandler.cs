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
    public class GetFavoriteSummonersCommandHandler : IRequestHandler<GetFavoriteSummonersCommand, IEnumerable<Summoner>>
    {
        private readonly ISummonersRepository _repository;

        public GetFavoriteSummonersCommandHandler(ISummonersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Summoner>> Handle(GetFavoriteSummonersCommand request, CancellationToken cancellationToken)
        {
            var summoners = await _repository.GetFavoriteSummoners();

            return summoners;            
        }
    }
}
