using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Infrastructure.Models
{
    public class ParticipantStats
    {
        public string Puuid { get; set; }

        public string RiotIdGameName { get; set; }

        public string ChampionName { get; set; }

        public string TeamPosition { get; set; }

        public double TotalDamageDealtToChampions { get; set; }

        public double TotalDamageTaken { get; set; }

        public Challenges Challenges { get; set; }

        public string MatchId { get; set; }
    }    

    public class Challenges
    {
        public double TeamDamagePercentage { get; set; }

        public double DamagePerMinute { get; set; }

        public int SkillshotsDodged { get; set; }

        public int SkillshotsHit { get; set; }

        public double Kda { get; set; }

        public int StealthWardsPlaced { get; set; }
    }
}
