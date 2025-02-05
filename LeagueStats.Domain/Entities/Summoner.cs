using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Transactions;
using LeagueStats.Domain.Core.DomainObjects;

namespace LeagueStats.Domain.Entities
{
    public class Summoner : Entity, IAggregateRoot
    {
        public Summoner(string id, string gameName, string tagline)
        {
            Id = id;
            GameName = gameName;
            Tagline = tagline;
        }

        protected Summoner() { }

        public string GameName { get; private set; }

        public string Tagline { get; private set; }

        public void Validate()
        {
            Validations.AssertArgumentNotEmpty(Id, "Id property cannot be empty");
            Validations.AssertArgumentNotEmpty(GameName, "GameName property cannot be empty");
            Validations.AssertArgumentNotEmpty(Tagline, "Tagline property cannot be empty");
        }
    }
}
