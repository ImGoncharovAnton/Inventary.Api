using Inventary.Domain.Entities;

namespace Inventary.Repositories.Contracts;

public interface IRoomRepository
{
    Task<IEnumerable<RoomEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<RoomEntity> GetByIdAsync(Guid roomId, CancellationToken cancellationToken = default);
    void Insert(RoomEntity roomEntity);
    void Remove(RoomEntity roomEntity);
}