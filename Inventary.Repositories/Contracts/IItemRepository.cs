using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;

namespace Inventary.Repositories.Contracts;

public interface IItemRepository<Item>
{
    Task<IList<ListItemsForStorage>> GetAllAsync();
    Task<IList<ItemsList>> GetListItemsAsync();
    Task<Item> GetByIdAsync(Guid id);
    Task<Item> Add(Item entity);
    Task<Item> Update(Item entity);
    Item Remove(Item entity);
    void RemoveRange(IList<Item> items);
}