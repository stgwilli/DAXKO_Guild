using System;
using System.Collections.Generic;
using Daxko.Guild.Domain.infrastructure;

namespace Daxko.Guild.Domain.extensions
{
    public static class EnumerationExtensions
    {
        public static IEnumerable<T> that_match<T>(this IEnumerable<T> items, ISpecification<T> specification)
        {
            foreach (var item in items)
                if (specification.is_satisfied_by(item)) 
                    yield return item;
        }

        public static IEnumerable<T> that_match<T>(this IEnumerable<T> items, Predicate<T> condition)
        {
            return that_match(items, new AnonymousSpecification<T>(condition));
        }
    }
}