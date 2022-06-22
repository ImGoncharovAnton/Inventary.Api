using Inventary.Repositories.Contracts;
using Inventary.Repositories.Repositories;

namespace Inventary.Repositories.Infrastructure;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IRoomRepository> _lazyRoomRepository;

    public RepositoryManager(ApplicationDbContext dbContext)
    {
        _lazyRoomRepository = new Lazy<IRoomRepository>(() => new RoomRepository(dbContext));
    }

    public IRoomRepository RoomRepository => _lazyRoomRepository.Value;
}