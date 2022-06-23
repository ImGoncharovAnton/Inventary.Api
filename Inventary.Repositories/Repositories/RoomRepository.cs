using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Repositories.Repositories;

internal sealed class RoomRepository: IRoomRepository
{
    private readonly ApplicationDbContext _dbContext;

    public RoomRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<RoomEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.Rooms.ToListAsync(cancellationToken);
    

    public async Task<RoomEntity> GetByIdAsync(Guid roomId, CancellationToken cancellationToken = default) =>
         await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == roomId, cancellationToken);


    public void Insert(RoomEntity roomEntity) =>
        _dbContext.Rooms.Add(roomEntity);

    public void Remove(RoomEntity roomEntity) =>
        _dbContext.Rooms.Remove(roomEntity);
}