using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueStats.Domain.Core.DomainObjects
{
    public abstract class Entity
    {
        public string Id { get; set; }

        public override bool Equals(object? obj)
        {
            var comparationObject = obj as Entity;

            if (ReferenceEquals(this, comparationObject)) return true;
            if (comparationObject is null) return false;

            return Id.Equals(comparationObject.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Código exclusivo de cada classe. Cada entidade terá um valor único.
        /// </summary>
        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }
    }
}
