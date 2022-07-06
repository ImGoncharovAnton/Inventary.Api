using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Repositories.Repositories;

public class RoomRepository : GenericRepository<Room>, IRoomRepository
{
    private readonly ApplicationDbContext _dbContext;
    public RoomRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Room>> GetAllWithItems()
    {
        return await _dbContext.Rooms.Include(x => x.Items).ToListAsync();
    }

    public async Task<List<ItemsForRoom>> GetByIdWithItems(Guid id)
    {
        var room = await _dbContext.Rooms.FindAsync(id);
       if (room is null)
           throw new ArgumentNullException();
       var itemsForRoom = await _dbContext.Items
           .Where(i => i.RoomId == id)
           .Select(i => new ItemsForRoom()
           {
               Id = i.Id,
               ItemName = i.ItemName,
               UserDate = i.UserDate,
               Status = i.Status,
               Price = i.Price,
               QRcode = i.QRcode,
               RoomName = room.RoomName
           }).ToListAsync();
       return itemsForRoom;
    }
}