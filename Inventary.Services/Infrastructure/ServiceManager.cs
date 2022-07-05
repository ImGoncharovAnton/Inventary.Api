using System.Reflection;
using System.Runtime.CompilerServices;
using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
using Inventary.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inventary.Services.Infrastructure;

public sealed class ServiceManager: IServiceManager
{
    private readonly Lazy<IRoomService> _lazyRoomService;
    private readonly Lazy<IUserService> _lazyUserService;
    private readonly Lazy<IItemService> _lazyItemService;
    private readonly IMapper _mapper;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _mapper = mapper;
        _lazyRoomService = new Lazy<IRoomService>(() => new RoomService(repositoryManager, mapper));
        _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
        _lazyItemService = new Lazy<IItemService>(() => new ItemService(repositoryManager, mapper));
    }
    
    public IRoomService RoomService => _lazyRoomService.Value;
    public IUserService UserService => _lazyUserService.Value;
    public IItemService ItemService => _lazyItemService.Value;
}

