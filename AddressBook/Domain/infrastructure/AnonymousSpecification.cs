using System;
using Daxko.Guild.Domain.extensions;

namespace Daxko.Guild.Domain.infrastructure
{
    public class AnonymousSpecification<T> : ISpecification<T>
    {
        Predicate<T> condition;

        public AnonymousSpecification(Predicate<T> condition)
        {
            this.condition = condition;
        }

        public bool is_satisfied_by(T item)
        {
            return condition(item);
        }
    }
}