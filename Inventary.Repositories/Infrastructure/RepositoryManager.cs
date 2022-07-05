using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;
using Inventary.Repositories.Repositories;

namespace Inventary.Repositories.Infrastructure;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IRoomRepository> _lazyRoomRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
    private readonly Lazy<IUserRepository> _lazyUserRepository;
    private readonly Lazy<IItemRepository<Item>> _lazyItemRepository;

    public RepositoryManager(ApplicationDbContext dbContext)
    {
        _lazyRoomRepository = new Lazy<IRoomRepository>(() => new RoomRepository(dbContext));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
        _lazyItemRepository = new Lazy<IItemRepository<Item>>(() => new ItemRepository(dbContext));
    }

    public IRoomRepository RoomRepository => _lazyRoomRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    public IUserRepository UserRepository => _lazyUserRepository.Value;
    public IItemRepository<Item> ItemRepository => _lazyItemRepository.Value;
}