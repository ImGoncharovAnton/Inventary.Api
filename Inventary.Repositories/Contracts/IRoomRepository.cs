using Inventary.Domain.Entities;

namespace Inventary.Repositories.Contracts;

public interface IRoomRepository
{
    Task<IEnumerable<RoomEntity>> GetAllAsync();
    Task<RoomEntity> GetByIdAsync(Guid roomId);
    void Insert(RoomEntity roomEntity);
    void Remove(RoomEntity roomEntity);
    void SaveChangesAsync();
}