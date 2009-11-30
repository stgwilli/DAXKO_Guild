using System;
using System.Collections.Generic;

namespace Daxko.Guild.Domain.extensions
{
    public static class EnumerationExtensions
    {
        public static IEnumerable<T> that_match<T>(this IEnumerable<T> items, Predicate<T> condition)
        {
            foreach (var item in items)
            {
                if(condition(item))
                    yield return item;
            }         
        }

        public static IEnumerable<T> or <T>(this IEnumerable<T>items, Predicate<T> condition)
        {
            
        }
    }
}