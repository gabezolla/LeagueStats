using LeagueStats.Domain.Entities;
using LeagueStats.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace LeagueStats.Data.Repository
{
    public class MembersRepository : IMembersRepository
    {
        private readonly LeagueStatsDbContext _context;

        public MembersRepository(LeagueStatsDbContext context)
        {
            _context = context;
        }

        public async Task<Member?> GetMemberByEmail(string email)
        {
            var members = await _context.Members.AsNoTracking().ToListAsync();

            return members.FirstOrDefault(m => m.Email == email);
        }

        public async Task<Member?> GetMemberById(string id)
        {
            var members = await _context.Members.AsNoTracking().ToListAsync();

            return members.FirstOrDefault(m => m.Id == id);
        }
    }
}
