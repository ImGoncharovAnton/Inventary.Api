using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;
using Inventary.Repositories.Repositories;

namespace Inventary.Repositories.Infrastructure;

public class RepositoryManager : IRepositoryManager
{
    // private readonly Lazy<IRoomRepository> _lazyRoomRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
    private readonly Lazy<IRepositoryRooms<RoomEntity>> _lazyRepository;
    

    public RepositoryManager(ApplicationDbContext dbContext)
    {
        // _lazyRoomRepository = new Lazy<IRoomRepository>(() => new RoomRepository(dbContext));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        _lazyRepository = new Lazy<IRepositoryRooms<RoomEntity>>(() => new RepositoryRooms<RoomEntity>(dbContext));
    }

    // public IRoomRepository RoomRepository => _lazyRoomRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    public IRepositoryRooms<RoomEntity> RepositoryRooms => _lazyRepository.Value;
    // public IRepository<RoomEntity> Repository { get; }
}