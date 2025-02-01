using LeagueStats.Domain.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Domain.Entities
{
    public class Stats : Entity
    {
        public Stats(string id, string champion, string lane, double damageDealt, double damageTaken, double stealthWardsPlaced, double teamDamagePercentage, double damagePerMinute, double skillshotsDodged, double kda)
        {
            Id = id;
            Champion = champion;
            Lane = lane;
            DamageDealt = damageDealt;
            DamageTaken = damageTaken;
            StealthWardsPlaced = stealthWardsPlaced;
            TeamDamagePercentage = teamDamagePercentage;
            DamagePerMinute = damagePerMinute;
            SkillshotsDodged = skillshotsDodged;
            Kda = kda;
        }

        public string Champion { get; private set; }

        public string Lane { get; private set; }

        public double DamageDealt { get; private set; }

        public double DamageTaken { get; private set; }

        public double StealthWardsPlaced { get; private set; }

        public double TeamDamagePercentage { get; private set; }

        public double DamagePerMinute { get; private set; }

        public double SkillshotsDodged { get; private set; }

        public double Kda { get; set; }

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
