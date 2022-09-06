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
    
    public async Task<IList<RoomDto>> GetAllAsync()
    {
        var rooms = await _repositoryManager.RoomRepository.GetAllAsync();
        var result = _mapper.Map<List<RoomDto>>(rooms);
        return result;
    }
    
    public async Task<RoomDto> GetByIdAsync(Guid id)
    {
        var room = await _repositoryManager.RoomRepository.GetByIdAsync(id);
        if (room is null)
            throw new RoomNotFoundException(id);
        var result = _mapper.Map<RoomDto>(room);
        
        return result;
    }

    public async Task<IList<CategoriesForRoom>> GetByIdWithCategory(Guid id)
    {
        return await _repositoryManager.RoomRepository.GetByIdWithCategory(id);
    }

    public async Task<IList<ItemsForRoom>> GetByIdWithItems(Guid id)
    {
        return await _repositoryManager.RoomRepository.GetByIdWithItems(id);
    }
    
    public async Task<bool> CreateRangeAsync(IList<CreateRoomDTO> rooms)
    {
        var mappedListRooms = _mapper.Map<List<Room>>(rooms);
        await _repositoryManager.RoomRepository.AddRange(mappedListRooms);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(Guid id, CreateRoomDTO createRoomDto)
    {
        var deciredRoom = await _repositoryManager.RoomRepository.GetByIdAsync(id);
        if (deciredRoom is null)
            throw new RoomNotFoundException(id);
        deciredRoom.RoomName = createRoomDto.RoomName;
        deciredRoom.UpdateDate = DateTime.UtcNow;

        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var room = await _repositoryManager.RoomRepository.GetByIdAsync(id);
        if (room is null)
            throw new RoomNotFoundException(id);
        
        _repositoryManager.RoomRepository.Remove(room);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return true;
    }
}