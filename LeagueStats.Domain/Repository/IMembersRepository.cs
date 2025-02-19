using LeagueStats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Domain.Repository
{
    public interface IMembersRepository
    {
        public Task<Member?> GetMemberById(string id);

        public Task<Member?> GetMemberByEmail(string email);
    }
}
