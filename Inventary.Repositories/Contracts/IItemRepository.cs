using Inventary.Domain.Entities;

namespace Inventary.Repositories.Contracts;

public interface IItemRepository<Item>
{
    Task<IList<Item>> GetAllAsync();
    Task<Item> GetByIdAsync(Guid id);
    Task<Item> Add(Item entity);
    Task<Item> Update(Item entity);
    void Upsert(Item entity);
    Item Remove(Item entity);
}