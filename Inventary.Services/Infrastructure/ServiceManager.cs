using System.Reflection;
using System.Runtime.CompilerServices;
using Inventary.Domain.Entities;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
using Inventary.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inventary.Services.Infrastructure;

public sealed class ServiceManager: IServiceManager
{
    private readonly Lazy<IRoomService> _lazyRoomService;
    private readonly Lazy<IServiceRoom> _lazyServiceRoom;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyRoomService = new Lazy<IRoomService>(() => new RoomService(repositoryManager));
        _lazyServiceRoom = new Lazy<IServiceRoom>(() => new ServiceRoom(repositoryManager));
    }
    
    public IRoomService RoomService => _lazyRoomService.Value;
    public IServiceRoom ServiceRoom => _lazyServiceRoom.Value;
    
}

