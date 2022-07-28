using System.Diagnostics;
using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Inventary.Repositories.Repositories;

public class ItemRepository : IItemRepository<Item>
{
    private readonly ApplicationDbContext _dbContext;


    public ItemRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IList<Item>> GetAllAsync()
    {
        var result = await _dbContext.Set<Item>()
            .Include(x => x.ItemPhotos)
            .ToListAsync();

        return result;
    }

    public async Task<IList<ItemsList>> GetListItemsAsync()
    {
        return await _dbContext.Items
            .Select(i => new ItemsList()
            {
                Id = i.Id,
                QrCode = i.QRcode,
                ItemName = i.ItemName,
                Status = i.Status,
                Date = i.UserDate,
                Price = i.Price,
                RoomName = i.Room.RoomName,
                NumberOfDefects = i.Defects.Count(),
                RoomId = i.RoomId,
                CategoryId = i.CurrentCategoryId,
                SetupId = i.SetupId,
                UserId = i.UserId
            }).ToListAsync();
    }

    public async Task<Item> GetByIdAsync(Guid id)
    {
        var result = await _dbContext.Items
            .Include(x => x.ItemPhotos)
            .Include(x => x.Attachments)
            .Include(x => x.Defects).ThenInclude(i => i.DefectPhotos)
            .Include(x => x.Comments)
            .FirstOrDefaultAsync(x => x.Id == id);

        return result;
    }

    public async Task<Item> Add(Item entity)
    {
        await _dbContext.Set<Item>().AddAsync(entity);
        return entity;
    }

    public async Task<Item> Update(Item entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        if (entity.ItemPhotos is not null)
            foreach (var itemPhoto in entity.ItemPhotos)
            {
                _dbContext.Entry(itemPhoto).State = EntityState.Modified;
                _dbContext.ItemPhotos.Update(itemPhoto);
            }
        _dbContext.Items.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public void Upsert(Item entity)
    {
        _dbContext.ChangeTracker.TrackGraph(entity, e =>
        {
            if (e.Entry.IsKeySet)
            {
                e.Entry.State = EntityState.Modified;
            }
            else
            {
                e.Entry.State = EntityState.Added;
            }
        });
        

#if DEBUG
        foreach (var entry in _dbContext.ChangeTracker.Entries())
        {
            Console.WriteLine($"Entity: {entry.Entity.GetType().Name} State: {entry.State.ToString()}");
        }
#endif
    }

    public Item Remove(Item entity)
    {
        _dbContext.Set<Item>().Remove(entity);
        return entity;
    }
}