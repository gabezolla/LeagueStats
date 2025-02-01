using AutoMapper;
using LeagueStats.Domain.Entities;
using LeagueStats.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LeagueStats.Infrastructure.Mappings
{
    public class ParticipantsStatsToStatsMappingProfile : Profile
    {
        public ParticipantsStatsToStatsMappingProfile()
        {
            CreateMap<ParticipantStats, Stats>()
                .ConstructUsing(src => new Stats(src.RiotIdGameName, src.ChampionName, src.TeamPosition, src.TotalDamageDealtToChampions, src.TotalDamageTaken, src.Challenges.StealthWardsPlaced, src.Challenges.TeamDamagePercentage, src.Challenges.DamagePerMinute, src.Challenges.SkillshotsDodged, src.Challenges.Kda));
        }
    }
}
