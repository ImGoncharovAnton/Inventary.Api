using Inventary.Domain.Entities;

namespace Inventary.Repositories.Contracts;

public interface IGenericRepository<T> where T: BaseEntity
{
    Task<IList<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    void Add(T entity);
    void Remove(T entity);
}