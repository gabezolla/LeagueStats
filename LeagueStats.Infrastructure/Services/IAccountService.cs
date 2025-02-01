using LeagueStats.Domain.Entities;
using LeagueStats.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Infrastructure.Services
{
    public interface IAccountService
    {
        Task<AccountDTO> GetSummonerById(string puuid);

        Task<AccountDTO> GetSummoner(string gameName, string tagLine);
    }
}
