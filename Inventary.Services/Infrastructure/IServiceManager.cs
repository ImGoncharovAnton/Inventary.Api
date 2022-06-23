using Inventary.Services.Contracts;

namespace Inventary.Services.Infrastructure;

public interface IServiceManager
{
    // IRoomService RoomService { get; }
    IServiceRoom ServiceRoom { get; }
}