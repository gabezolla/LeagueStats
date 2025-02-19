using LeagueStats.Domain.Entities;

namespace LeagueStats.Application.Abstractions
{
    public interface IJwtProvider
    {
        string GenerateToken(Member member);
    }
}
