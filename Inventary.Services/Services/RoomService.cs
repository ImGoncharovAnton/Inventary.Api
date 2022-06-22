using System.Linq.Expressions;
using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Domain.Extensions;
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

    public async Task<IEnumerable<RoomDTO>> GetAllAsync()
    {
        var rooms = await _repositoryManager.RoomRepository.GetAllAsync();
        var roomsDto = _mapper.Map<IEnumerable<RoomDTO>>(rooms);
        return roomsDto;
    }

    public async Task<RoomDTO> GetByIdAsync(Guid roomId)
    {
        var room = await _repositoryManager.RoomRepository.GetByIdAsync(roomId);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var roomDto = _mapper.Map<RoomDTO>(room);
        return roomDto;
    }

    public async Task<RoomDTO> CreateAsync(RoomDTO roomDto)
    {
        var room = _mapper.Map<RoomEntity>(roomDto);
         _repositoryManager.RoomRepository.Insert(room);

        return  _mapper.Map<RoomDTO>(room);
    }

    public Task UpdateAsync(Guid roomId, RoomDTO roomDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid roomId)
    {
        var room = await _repositoryManager.RoomRepository.GetByIdAsync(roomId);

        if (room is null)
            throw new RoomNotFoundException(roomId);
        
        _repositoryManager.RoomRepository.Remove(room);
    }
}