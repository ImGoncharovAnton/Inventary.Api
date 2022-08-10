using Inventary.Services.Contracts;

namespace Inventary.Services.Infrastructure;

public interface IServiceManager
{
    IRoomService RoomService { get; }
    IUserService UserService { get; }
    IItemService ItemService { get; }
    ICategoryService CategoryService { get; }
    ISetupService SetupService { get; }
}