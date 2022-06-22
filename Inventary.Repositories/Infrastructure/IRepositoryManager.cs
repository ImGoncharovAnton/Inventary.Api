using Inventary.Repositories.Contracts;

namespace Inventary.Repositories.Infrastructure;

public interface IRepositoryManager
{
    IRoomRepository RoomRepository { get; }
}