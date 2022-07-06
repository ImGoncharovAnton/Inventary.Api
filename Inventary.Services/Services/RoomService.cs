using System.Linq.Expressions;
using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Repositories.Contracts;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
using Inventary.Services.Extensions;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Services;

public class RoomService : IRoomService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public RoomService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public RoomService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IList<RoomDto>> GetAllAsync()
    {
        var rooms = await _repositoryManager.RoomRepository.GetAllAsync();
        var result = _mapper.Map<List<RoomDto>>(rooms);
        return result;
    }

    public async Task<IList<RoomDto>> GetAllAsyncWithItems()
    {
        var rooms = await _repositoryManager.RoomRepository.GetAllWithItems();
        var result = _mapper.Map<List<RoomDto>>(rooms);
        return result;
    }

    public async Task<RoomDto> GetByIdAsync(Guid id)
    {
        var room = await _repositoryManager.RoomRepository.GetByIdAsync(id);
        if (room is null)
            throw new RoomNotFoundException(id);
        var result = new RoomDto()
        {
            Id = room.Id,
            RoomName = room.RoomName
        };
        
        return result;
    }

    public async Task<IList<ItemsForRoom>> GetByIdWithItems(Guid id)
    {
        return await _repositoryManager.RoomRepository.GetByIdWithItems(id);
    }

    public async Task<Room> CreateAsync(CreateRoomDTO createRoomDto)
    {
        if (createRoomDto.RoomName == string.Empty)
            throw new Exception("Room Name cant be empty");
        var room = new Room()
        {
            Id = new Guid(),
            CreatedDate = DateTime.UtcNow,
            UpdateDate = DateTime.UtcNow,
            RoomName = createRoomDto.RoomName
        };
        _repositoryManager.RoomRepository.Add(room);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return room;
    }

    public async Task UpdateAsync(Guid id, CreateRoomDTO createRoomDto)
    {
        var deciredRoom = await _repositoryManager.RoomRepository.GetByIdAsync(id);
        if (deciredRoom is null)
            throw new RoomNotFoundException(id);
        deciredRoom.RoomName = createRoomDto.RoomName;
        deciredRoom.UpdateDate = DateTime.UtcNow;

        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var room = await _repositoryManager.RoomRepository.GetByIdAsync(id);
        if (room is null)
            throw new RoomNotFoundException(id);
        
        _repositoryManager.RoomRepository.Remove(room);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }
}