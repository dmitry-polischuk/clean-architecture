
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IMergeable<T> where T : DomainBase
    {
        public void Merge(T destination);
        public bool CanBeMerged(T destination);
        public bool RedundantInList(List<T> items);
    }
}
