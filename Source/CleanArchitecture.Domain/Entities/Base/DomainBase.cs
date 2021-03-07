using System;

namespace CleanArchitecture.Domain.Entities
{
    public class DomainBase
    {
        protected string CompareStrings(string oldValue, string newValue)
        {
            return string.Equals(oldValue, newValue, StringComparison.OrdinalIgnoreCase)
                    ? oldValue
                    : newValue ?? oldValue;
        }
    }
}
