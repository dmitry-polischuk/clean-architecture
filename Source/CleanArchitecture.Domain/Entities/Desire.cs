using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class Desire : DomainBase, IMergeable<Desire>
    {
        public Guid DesireId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public eDesireStatus Status { get; set; }
        public User User { get; set; }

        public bool CanBeMerged(Desire destination)
        {
            return this.DesireId != null && this.DesireId == destination.DesireId;
        }

        public void Merge(Desire destination)
        {
            this.Name = CompareStrings(this.Name, destination.Name);
        }

        public bool RedundantInList(List<Desire> items)
        {
            return !items.Select(d => d.DesireId).Contains(this.DesireId);
        }
    }
}


