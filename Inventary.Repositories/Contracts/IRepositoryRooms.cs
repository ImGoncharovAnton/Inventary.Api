using Inventary.Domain.Entities;

namespace Inventary.Repositories.Contracts;

public interface IRepositoryRooms<T> where T:BaseEntity
{
    IEnumerable<T> GetAll();
    // Task<IList<T>> GetAll();
    Task<T> GetByIdAsync(Guid id);
    void Insert(T entity);
    // void Update(T entity);
    void Remove(T entity);
}