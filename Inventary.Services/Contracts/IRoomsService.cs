using Inventary.Domain.Entities;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface IRoomsService
{
    Task<IEnumerable<RoomEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<RoomEntity> GetByIdAsync(Guid roomId, CancellationToken cancellationToken = default);
    Task<RoomEntity> CreateAsync(RoomEntity roomEntity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid roomId, RoomEntity roomEntity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid roomId, CancellationToken cancellationToken = default);
}