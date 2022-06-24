using Inventary.Domain.Entities;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface IRoomService
{
    Task<IList<RoomDTO>> GetAllAsync();
    Task<RoomEntity> GetByIdAsync(Guid id);
    Task<RoomEntity> CreateAsync(CreateRoomDTO room);
    Task UpdateAsync(Guid id, CreateRoomDTO room);
    Task DeleteAsync(Guid id);
}