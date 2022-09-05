using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface IRoomService
{
    Task<IList<RoomDto>> GetAllAsync();
    Task<RoomDto> GetByIdAsync(Guid id);
    Task<IList<CategoriesForRoom>> GetByIdWithCategory(Guid id);
    Task<IList<ItemsForRoom>> GetByIdWithItems(Guid id);
    Task<bool> CreateRangeAsync(IList<CreateRoomDTO> rooms);
    Task<bool> UpdateAsync(Guid id, CreateRoomDTO room);
    Task<bool> DeleteAsync(Guid id);
}