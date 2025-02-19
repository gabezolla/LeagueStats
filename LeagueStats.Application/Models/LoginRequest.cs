using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Application.Models
{
    public class LoginRequest
    {
        public LoginRequest(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
