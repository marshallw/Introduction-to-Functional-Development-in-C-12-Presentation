namespace Persistence;

public interface IReadOnlyRepository<T>
{
    IEnumerable<T> GetAll();
}