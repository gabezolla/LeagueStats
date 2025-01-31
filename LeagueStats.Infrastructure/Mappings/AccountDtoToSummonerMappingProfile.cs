using AutoMapper;
using LeagueStats.Domain.Entities;
using LeagueStats.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Infrastructure.Mappings
{
    public class AccountDtoToSummonerMappingProfile : Profile
    {
        public AccountDtoToSummonerMappingProfile() {
            CreateMap<AccountDTO, Summoner>()
                .ConstructUsing(src => new Summoner(src.Puuid, src.GameName, src.TagLine));
        }
    }
}
