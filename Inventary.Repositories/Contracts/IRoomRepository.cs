using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;

namespace Inventary.Repositories.Contracts;

public interface IRoomRepository : IGenericRepository<Room>
{
    Task<List<ItemsForRoom>> GetByIdWithItems(Guid id);
    Task<List<CategoriesForRoom>> GetByIdWithCategory(Guid id);
    Task AddRange(IList<Room> rooms);
}