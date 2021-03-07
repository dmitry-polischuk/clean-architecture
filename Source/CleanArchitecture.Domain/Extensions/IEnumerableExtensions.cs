using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Domain.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void Merge<T>(this List<T> source, List<T> destination) where T : DomainBase, IMergeable<T>
        {
            if (destination != null)
            {
                if (destination.Any())
                {
                    AddOrUpdate(source, destination);
                    RemoveRedundant(source, destination);
                }
                else
                {
                    source.Clear();
                }
            }
        }

        private static void AddOrUpdate<T>(List<T> source, List<T> destination) where T : DomainBase, IMergeable<T>
        {
            foreach (var destinationItem in destination)
            {
                var oldMedication = source.FirstOrDefault(t => t.CanBeMerged(destinationItem));
                if (oldMedication == null)
                {
                    source.Add(destinationItem);
                }
                else
                {
                    oldMedication.Merge(destinationItem);
                }
            }
        }

        private static void RemoveRedundant<T>(List<T> source, List<T> destination) where T : DomainBase, IMergeable<T>
        {
            var redundantItems = source.Where(s => s.RedundantInList(destination)).ToList();
            if (redundantItems.Any())
            {
                foreach (var item in redundantItems)
                {
                    source.Remove(item);
                }
            }
        }
    }
}
