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
            .Where(i => i.RoomId == room.Id)
            .Select(i => new ItemsForRoom()
            {
                Id = i.Id,
                ItemName = i.ItemName,
                UserDate = i.UserDate,
                Status = i.Status,
                Price = i.Price,
                QRcode = i.QRcode,
                RoomName = room.RoomName,
                CategoryId = i.CategoryId
            }).ToListAsync();
        
        
        // var test = await  _dbContext.Categories.Include(x => x.Items).ThenInclude(x => x.Rooms).Where(x => x.Rooms.id == 201)

        
        // var test = await _dbContext.Rooms.Include(x => x.Items).ThenInclude(x => x.Category);
        //
        //
        // var unicCategory = test.Select(x => x.Category).Distinct();
        //
        // foreach (var caategory in unicCategory)
        // {
        //     var test213 = test.Select(x => x.items).where(x => x.categoryId == unicCategory.id);
        //
        // }
        
        
        return itemsForRoom;
    }

    public async Task<List<Category>> GetByIdWithCategory(Guid id)
    {
        var room = await _dbContext.Rooms.FindAsync(id);
        if (room is null)
            throw new ArgumentNullException();

        // var test = await _dbContext.Categories
        //     .Include(x => x.Items)
        //     .ThenInclude(x => x.Room)
        //     .ToListAsync();
        //     
        
        var categoriesForRoom = await _dbContext.Rooms.Include(x => x.Items)
            .ThenInclude(x => x.Category)
            .Where(x => x.Id == room.Id)
            .ToListAsync();

        var getCategories = categoriesForRoom.SelectMany(x => x.Items.Select(z => 
           z.Category)).Distinct().ToList();
        

        // var result = getCategories.Select(x => new CategoriesForRoom()
        // {
        //     Id = x.Id,
        //     CategoryName = x.CategoryName,
        //     NumbersOfItems = x.Items.Count
        // }).ToList();
      
        return getCategories;
    }
}