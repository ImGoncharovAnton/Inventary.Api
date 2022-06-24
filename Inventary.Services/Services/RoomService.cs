using System.Linq.Expressions;
using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Domain.Extensions;
using Inventary.Repositories.Contracts;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
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

    public async Task<IList<RoomDTO>> GetAllAsync()
    {
        var rooms = await _repositoryManager.RoomRepository.GetAllAsync();
        // var roomsDto = _mapper.Map<List<RoomDTO>>(rooms);
        return rooms.Select(room => new RoomDTO() { Id = room.Id, RoomName = room.RoomName }).ToList();
    }

    public async Task<RoomEntity> GetByIdAsync(Guid id)
    {
        var room = await _repositoryManager.RoomRepository.GetByIdAsync(id);
        if (room is null)
            throw new RoomNotFoundException(id);
        
        return room;
    }

    public async Task<RoomEntity> CreateAsync(CreateRoomDTO createRoomDto)
    {
        if (createRoomDto.RoomName == string.Empty)
            throw new Exception("Room Name cant be empty");
        var room = new RoomEntity()
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