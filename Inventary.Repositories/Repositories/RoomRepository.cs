using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Repositories.Repositories;

internal sealed class RoomRepository: IRoomRepository
{
    private readonly ApplicationDbContext _dbContext;
    private DbSet<RoomEntity> rooms;

    public RoomRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        rooms = _dbContext.Set<RoomEntity>();
    }

    public async Task<IEnumerable<RoomEntity>> GetAllAsync()
    {

        var tedt = new RoomEntity()
        {
            CreatedDate = DateTime.Now,
            RoomName = "Tesdt",
            UpdateDate = DateTime.Now
        };

        await rooms.AddAsync(tedt);
        this._dbContext.SaveChanges();

        return await rooms.ToListAsync();
        // await _dbContext.Rooms.ToListAsync();
    }

    public async Task<RoomEntity> GetByIdAsync(Guid roomId)
    {
        // if ()
        
        return await rooms.FirstOrDefaultAsync(x => x.Id == roomId);
    }

    public void Insert(RoomEntity roomEntity)
    {
        rooms.Add(roomEntity);
        _dbContext.SaveChangesAsync();
    }

    public void Remove(RoomEntity roomEntity)
    {
        rooms.Remove(roomEntity);
        _dbContext.SaveChangesAsync();
    }

    public void SaveChangesAsync()
    {
        _dbContext.SaveChangesAsync();
    }
}