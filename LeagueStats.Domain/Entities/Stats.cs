using LeagueStats.Domain.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Domain.Entities
{
    public class Stats : Entity, IAggregateRoot
    {
        public Stats(string matchId, string playerId, string champion, string lane, double damageDealt, double damageTaken, int stealthWardsPlaced, double teamDamagePercentage, double damagePerMinute, int skillshotsDodged, int skillshotsHit, double kda, string gameName)
        {
            Id = Guid.NewGuid().ToString();
            MatchId = matchId;
            PlayerId = playerId;
            Champion = champion;
            Lane = lane;
            DamageDealt = damageDealt;
            DamageTaken = damageTaken;
            StealthWardsPlaced = stealthWardsPlaced;
            TeamDamagePercentage = teamDamagePercentage;
            DamagePerMinute = damagePerMinute;
            SkillshotsDodged = skillshotsDodged;
            Kda = kda;
            GameName = gameName;
            SkillshotsHit = skillshotsHit;
        }

        public string MatchId { get; private set; }

        public string GameName { get; private set; }

        public string PlayerId { get; private set; }

        public string Champion { get; private set; }

        public string Lane { get; private set; }

        public double DamageDealt { get; private set; }

        public double DamageTaken { get; private set; }

        public int StealthWardsPlaced { get; private set; }

        public double TeamDamagePercentage { get; private set; }

        public double DamagePerMinute { get; private set; }

        public int SkillshotsDodged { get; private set; }

        public int SkillshotsHit { get; private set; }

        public double Kda { get; private set; }

        public void Validate()
        {
            Validations.AssertArgumentNotEmpty(Id, "Id property cannot be empty");
            Validations.AssertArgumentNotEmpty(Champion, "Champion property cannot be empty");
            Validations.AssertArgumentNotEmpty(Lane, "Lane property cannot be empty");
            Validations.AssertArgumentNotNull(DamageDealt, "DamageDealt property cannot be null");
            Validations.AssertArgumentNotNull(DamageTaken, "DamageTaken property cannot be null");
        }
    }
}
