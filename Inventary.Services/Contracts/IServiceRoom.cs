using Inventary.Domain.Entities;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface IServiceRoom
{
    IEnumerable<RoomEntity> GetAll();
    Task<RoomEntity> GetByIdAsync(Guid id);
    Task<RoomEntity> CreateAsync(RoomDTO room);
    Task UpdateAsync(Guid roomId, RoomDTO room);
    Task DeleteAsync(Guid id);
}