using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface IRoomService
{
    Task<IEnumerable<RoomDTO>> GetAllAsync();
    Task<RoomDTO> GetByIdAsync(Guid roomId);
    Task<RoomDTO> CreateAsync(RoomDTO roomDto);
    Task UpdateAsync(Guid roomId, RoomDTO roomDto);
    Task DeleteAsync(Guid roomId);
}