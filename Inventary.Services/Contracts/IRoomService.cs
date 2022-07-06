using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface IRoomService
{
    Task<IList<RoomDto>> GetAllAsync();
    Task<IList<RoomDto>> GetAllAsyncWithItems();
    Task<RoomDto> GetByIdAsync(Guid id);
    Task<IList<ItemsForRoom>> GetByIdWithItems(Guid id);
    Task<Room> CreateAsync(CreateRoomDTO room);
    Task UpdateAsync(Guid id, CreateRoomDTO room);
    Task DeleteAsync(Guid id);
}