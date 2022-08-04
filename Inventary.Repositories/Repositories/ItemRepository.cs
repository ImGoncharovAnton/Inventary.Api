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

    public async Task<IList<ListItemsForStorage>> GetAllAsync()
    {
        var listItems = await _dbContext.Items
            .Select(i => new ListItemsForStorage()
            {
                Id = i.Id,
                ItemName = i.ItemName,
                UserDate = i.UserDate,
                Status = i.Status,
                Price = i.Price,
                QRcode = i.QRcode,
                RoomName = i.Room.RoomName,
                SetupName = i.Setup.SetupName,
                NumberOfDefects = i.Defects.Count(),
                CategoryId = i.CurrentCategoryId,
                SetupId = i.SetupId,
                RoomId = i.RoomId
            }).ToListAsync();

        return listItems;
    }

    public async Task<IList<ItemsList>> GetListItemsAsync()
    {
        return await _dbContext.Items
            .Where(x => x.SetupId == null)
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

    public Item Remove(Item entity)
    {
        _dbContext.Set<Item>().Remove(entity);
        return entity;
    }

    public void RemoveRange(IList<Item> items)
    {
        _dbContext.Set<Item>().RemoveRange(items);
    }
}