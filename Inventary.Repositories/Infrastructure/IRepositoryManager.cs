using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;

namespace Inventary.Repositories.Infrastructure;

public interface IRepositoryManager
{
    // IRoomRepository RoomRepository { get; }
    IUnitOfWork UnitOfWork { get; }
    
    IRepositoryRooms<RoomEntity> RepositoryRooms { get; }
    IRoomRepository RoomRepository { get; }
}