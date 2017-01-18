namespace EnclosuresFinder.Data.Abstract
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
        ISpecification<T> And(ISpecification<T> specification);
    }
}
