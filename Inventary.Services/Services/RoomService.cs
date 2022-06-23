// using System.Collections;
// using System.Linq.Expressions;
// using AutoMapper;
// using Inventary.Domain.Entities;
// using Inventary.Domain.Extensions;
// using Inventary.Repositories.Infrastructure;
// using Inventary.Services.Contracts;
// using Inventary.Services.Models.DTO;
//
// namespace Inventary.Services.Services;
//
// internal sealed class RoomService : IRoomService
// {
//     private readonly IRepositoryManager _repositoryManager;
//     // private readonly IMapper _mapper;
//
//     // public RoomService(IRepositoryManager repositoryManager, IMapper mapper)
//     // {
//     //     _repositoryManager = repositoryManager;
//     //     _mapper = mapper;
//     // }
//
//     public RoomService(IRepositoryManager repositoryManager)
//     {
//         _repositoryManager = repositoryManager;
//     }
//
//     public async Task<IEnumerable<RoomEntity>> GetAllAsync(CancellationToken cancellationToken = default)
//     {
//         var rooms = await _repositoryManager.RoomRepository.GetAllAsync(cancellationToken);
//         // var roomsDto = _mapper.Map<IEnumerable<RoomDTO>>(rooms);
//         return rooms;
//     }
//
//     public async Task<RoomEntity> GetByIdAsync(Guid roomId, CancellationToken cancellationToken = default)
//     {
//         var room = await _repositoryManager.RoomRepository.GetByIdAsync(roomId, cancellationToken);
//         if (room is null)
//             throw new RoomNotFoundException(roomId);
//
//         // var roomDto = _mapper.Map<RoomDTO>(room);
//         return room;
//     }
//
//     public async Task<RoomEntity> CreateAsync(RoomEntity roomEntity, CancellationToken cancellationToken = default)
//     {
//         // var room = _mapper.Map<RoomEntity>(roomDto);
//          _repositoryManager.RoomRepository.Insert(roomEntity);
//          await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
//          return roomEntity;
//          // return  _mapper.Map<RoomDTO>(room);
//     }
//
//     public async Task UpdateAsync(Guid roomId, RoomEntity roomEntity, CancellationToken cancellationToken = default)
//     {
//         var room = await _repositoryManager.RoomRepository.GetByIdAsync(roomId, cancellationToken);
//         if (room is null)
//             throw new RoomNotFoundException(roomId);
//
//         room.RoomName = roomEntity.RoomName;
//         await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
//     }
//
//     public async Task DeleteAsync(Guid roomId, CancellationToken cancellationToken = default)
//     {
//         var room = await _repositoryManager.RoomRepository.GetByIdAsync(roomId, cancellationToken);
//
//         if (room is null)
//             throw new RoomNotFoundException(roomId);
//         
//         _repositoryManager.RoomRepository.Remove(room);
//         await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
//     }
// }