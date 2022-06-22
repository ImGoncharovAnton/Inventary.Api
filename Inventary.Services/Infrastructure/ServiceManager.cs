using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
using Inventary.Services.Services;

namespace Inventary.Services.Infrastructure;

public sealed class ServiceManager: IServiceManager
{
    private readonly Lazy<IRoomService> _lazyRoomService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyRoomService = new Lazy<IRoomService>(() => new RoomService(repositoryManager));
    }

    public IRoomService RoomService => _lazyRoomService.Value;
}
