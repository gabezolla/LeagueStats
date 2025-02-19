using LeagueStats.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Application.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public LoginCommand(LoginRequest loginRequest)
        {
            LoginRequest = loginRequest;
        }

        public LoginRequest LoginRequest { get; set; }
    }
}
