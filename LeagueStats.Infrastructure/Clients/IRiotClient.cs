using LeagueStats.Infrastructure.Models;
using LeagueStats.Infrastructure.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Infrastructure.Clients
{
    public interface IRiotClient 
    {
        public Task<T> Get<T>(string endpoint) where T : class;
    }
}
