using LeagueStats.Domain.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Domain.Entities
{
    public class Member : Entity, IAggregateRoot
    {
        public string Email { get; private set; }
    }
}
