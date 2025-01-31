using LeagueStats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        public Task<Summoner> GetSummoner(string puuid)
        {
            throw new NotImplementedException();
        }
    }
}
