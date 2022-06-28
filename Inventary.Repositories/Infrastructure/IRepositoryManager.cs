using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;

namespace Inventary.Repositories.Infrastructure;

public interface IRepositoryManager
{
    IUnitOfWork UnitOfWork { get; }
    IRoomRepository RoomRepository { get; }
    IUserRepository UserRepository { get; }
}