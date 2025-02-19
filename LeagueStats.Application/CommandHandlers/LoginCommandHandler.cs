using LeagueStats.Application.Abstractions;
using LeagueStats.Application.Commands;
using LeagueStats.Domain.Core.DomainObjects;
using LeagueStats.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Application.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IMembersRepository _membersRepository;
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(IMembersRepository membersRepository, IJwtProvider jwtProvider)
        {
            _membersRepository = membersRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var member = await _membersRepository.GetMemberByEmail(request.LoginRequest.Email);

            if(member is null)
            {
                throw new DomainException(DomainErrors.InvalidCredentials);
            }

            return _jwtProvider.GenerateToken(member);
        }
    }
}
