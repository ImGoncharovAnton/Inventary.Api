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

    public async Task<ListItemsForStorageResponse> GetItemsWithFilters(RequestParams parameters)
    {

        var items = from s in _dbContext.Items
            select s;
        
        #region Filter&SortLogic

        if (parameters.FilterByRoom != null || parameters.FilterBySetup != null || parameters.FilterByStatus != null ||
            parameters.FilterByDateStart != null || parameters.FilterByPriceStart != null)
        {
            parameters.PageIndex = 1;
        }
        
        if (!String.IsNullOrEmpty(parameters.SearchString))
        {
            parameters.PageIndex = 1;
            items = items.Where(l =>
                l.ItemName.Trim().ToLower().Contains(parameters.SearchString.Trim().ToLower())
                || l.Room.RoomName.Trim().ToLower().Contains(parameters.SearchString.Trim().ToLower())
                || l.Setup.SetupName.Trim().ToLower().Contains(parameters.SearchString.Trim().ToLower()));
        }

        var listItems = await items
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
        
        
        if (parameters.SortOrderBy is not null)
        {
            switch (parameters.SortOrderBy)
            {
                case "itemName_asc":
                    listItems = listItems.OrderBy(i => i.ItemName).ToList();
                    break;
                case "itemName_desc":
                    listItems = listItems.OrderByDescending(i => i.ItemName).ToList();
                    break;
                case "date_asc":
                    listItems = listItems.OrderBy(i => i.UserDate).ToList();
                    break;
                case "date_desc":
                    listItems = listItems.OrderByDescending(i => i.UserDate).ToList();
                    break;
                case "price_asc":
                    listItems = listItems.OrderBy(i => i.Price).ToList();
                    break;
                case "price_desc":
                    listItems = listItems.OrderByDescending(i => i.Price).ToList();
                    break;
                case "room_asc":
                    listItems = listItems.OrderBy(i => i.RoomName).ToList();
                    break;
                case "room_desc":
                    listItems = listItems.OrderByDescending(i => i.RoomName).ToList();
                    break;
                case "setup_asc":
                    listItems = listItems.OrderBy(i => i.SetupName).ToList();
                    break;
                case "setup_desc":
                    listItems = listItems.OrderByDescending(i => i.SetupName).ToList();
                    break;
                case "numberOfDefects_asc":
                    listItems = listItems.OrderBy(i => i.NumberOfDefects).ToList();
                    break;
                case "numberOfDefects_desc":
                    listItems = listItems.OrderByDescending(i => i.NumberOfDefects).ToList();
                    break;
            }
        }
        else
        {
            listItems = listItems.OrderBy(i => i.ItemName).ToList();
        }


        listItems = listItems.Where(x =>
            ((parameters.FilterBySetup is null) || x.SetupName == parameters.FilterBySetup)
            && ((parameters.FilterByRoom is null) || x.RoomName == parameters.FilterByRoom)
            && ((parameters.FilterByStatus is null) || x.Status == parameters.FilterByStatus)
            && ((parameters.FilterByDateStart is null) || x.UserDate >= parameters.FilterByDateStart && x.UserDate <= parameters.FilterByDateEnd)
            && ((parameters.FilterByPriceStart is null) || x.Price >= parameters.FilterByPriceStart && x.Price <= parameters.FilterByPriceEnd)).ToList();
        
        #endregion
        
        var resultList = PaginatedList<ListItemsForStorage>.CreateAsync(listItems, parameters.PageIndex,
            parameters.PageSize);
        
        var response = new ListItemsForStorageResponse()
        {
            Items = resultList,
            TotalCount = resultList.TotalCount,
            PageSize = resultList.PageSize,
            PageIndex = resultList.PageIndex,
            TotalPages = resultList.TotalPages,
            HasNextPage = resultList.HasNextPage,
            HasPreviousPage = resultList.HasPreviousPage
        };


        return response;
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
                CategoryName = i.Category.CategoryName,
                SetupId = i.SetupId,
                UserId = i.UserId
            }).ToListAsync();
    }

    public async Task<IList<ItemsList>> GetListItemsBySetupId(Guid id)
    {
        var findSetup = await _dbContext.Setups.FindAsync(id);
        if (findSetup is null)
            throw new Exception("Setup is not found");

        return await _dbContext.Items
            .Where(x => x.SetupId == id)
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
                CategoryName = i.Category.CategoryName,
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
            .Include(x => x.Room)
            .Include(x => x.Category)
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