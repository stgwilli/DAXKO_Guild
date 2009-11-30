namespace Daxko.Guild.Domain.infrastructure
{
    public interface ISpecification<T>
    {
        bool is_satisfied_by(T item);
    }
}