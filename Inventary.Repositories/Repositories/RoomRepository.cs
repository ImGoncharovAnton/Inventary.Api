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
    
    public async Task<List<ItemsForRoom>> GetByIdWithItems(Guid id)
    {
        var room = await _dbContext.Rooms.FindAsync(id);
        if (room is null)
            throw new Exception($"The room with the identifier {id} was not found.");
        var itemsForRoom = await _dbContext.Items
            .Where(i => i.RoomId == room.Id)
            .Select(i => new ItemsForRoom()
            {
                Id = i.Id,
                ItemName = i.ItemName,
                UserDate = i.UserDate,
                Status = i.Status,
                Price = i.Price,
                QRcode = i.QRcode,
                SetupName = i.Setup.SetupName,
                CurrentCategoryId = i.CurrentCategoryId,
                Defects = i.Defects
            }).ToListAsync();
        
        return itemsForRoom;
    }

    public async Task<List<CategoriesForRoom>> GetByIdWithCategory(Guid id)
    {
        var room = await _dbContext.Rooms.FindAsync(id);
        if (room is null)
            throw new Exception($"The room with the identifier {id} was not found.");
        
        var categoriesForRoom = await _dbContext.Rooms
            .Include(x => x.Items)
            .ThenInclude(x => x.Category)
            .Where(x => x.Id == room.Id)
            .ToListAsync();

        var getCategories = categoriesForRoom
            .SelectMany(x => x.Items.Where(z => z.CurrentCategoryId != null).Select(z => 
           z.Category)).Distinct().ToList();
        

        var result = getCategories.Select(x => new CategoriesForRoom()
        {
            Id = x.Id,
            CategoryName = x.CategoryName,
            NumbersOfItems = x.Items.Count()
        }).ToList();
      
        return result;
    }

    public async Task AddRange(IList<Room> rooms)
    {
        await _dbContext.Rooms.AddRangeAsync(rooms);
    }
}