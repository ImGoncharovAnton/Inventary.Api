using Inventary.Domain.Entities;
using Inventary.Domain.Extensions;
using Inventary.Repositories.Contracts;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Services;

public class ServiceRoom : IServiceRoom
{
    private readonly IRepositoryManager _repositoryManager;

    public ServiceRoom(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public IEnumerable<RoomEntity> GetAll()
    {
        return _repositoryManager.RepositoryRooms.GetAll();
    }

    public async Task<RoomEntity> GetByIdAsync(Guid id)
    {
        return await _repositoryManager.RepositoryRooms.GetByIdAsync(id);
    }

    public async Task<RoomEntity> CreateAsync(RoomDTO roomDto)
    {
        var room = new RoomEntity()
        {
            Id = new Guid(),
            CreatedDate = DateTime.UtcNow,
            UpdateDate = DateTime.UtcNow,
            RoomName = roomDto.RoomName
        };
        _repositoryManager.RepositoryRooms.Insert(room);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return room;
    }

    public async Task UpdateAsync(Guid roomId, RoomDTO room)
    {
        var deciredRoom = await _repositoryManager.RepositoryRooms.GetByIdAsync(roomId);
        if (deciredRoom is null)
             throw new RoomNotFoundException(roomId);
        deciredRoom.RoomName = room.RoomName;
        deciredRoom.UpdateDate = DateTime.UtcNow;

        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var room = await _repositoryManager.RepositoryRooms.GetByIdAsync(id);
        if (room is null)
             throw new RoomNotFoundException(id);
        
        _repositoryManager.RepositoryRooms.Remove(room);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();

    }
}