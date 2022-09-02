using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Domain.Enums;
using Inventary.Repositories.Common.Models;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
using Inventary.Services.Extensions;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Services;

public class ItemService : IItemService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;


    public ItemService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IList<ListItemsForStorage>> GetAllItems()
    {
        var items = await _repositoryManager.ItemRepository.GetAllAsync();
        return items;
    }

    public async Task<ListItemsForStorageResponse> GetItemsByPage(RequestParams parameters)
    {
        var items = await _repositoryManager.ItemRepository.GetItemsWithFilters(parameters);
        return items;
    }

    public async Task<IList<ItemsList>> GetItemsListAsync()
    {
        return await _repositoryManager.ItemRepository.GetListItemsWithoutSetupAsync();
    }

    public async Task<IList<ItemsList>> GetItemsListBySetupId(Guid id)
    {
        return await _repositoryManager.ItemRepository.GetListItemsBySetupId(id);
    }

    public async Task<ItemDto> GetByIdAsync(Guid id)
    {
        var item = await _repositoryManager.ItemRepository.GetByIdAsync(id);
        if (item is null)
            throw new ItemNotFoundException(id);
        var result = _mapper.Map<ItemDto>(item);

        return result;
    }

    public async Task<ItemDto> CreateAsync(CreateItemDto createItem)
    {

        var notValidItemName = createItem.ItemName.Equals(String.Empty);
        var notValidByPositivePrice = createItem.Price < 0;

        if (notValidItemName)
        {
            throw new Exception("ItemName field cannot be empty!");
        }

        if (notValidByPositivePrice)
        {
            throw new Exception("Price can only be positive!");
        }
        
        var newItem = _mapper.Map<Item>(createItem);

        var item = await _repositoryManager.ItemRepository.Add(newItem);

        var result = _mapper.Map<ItemDto>(item);

        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return result;
    }

    public async Task<ItemDto> UpdateAsync(Guid itemId, UpdateItemDto item)
    {
        var notValidItemName = item.ItemName.Equals(String.Empty);
        var notValidByPositivePrice = item.Price < 0;
        var notNullableUserDate = item.UserDate ?? DateTime.UtcNow;

        if (notValidItemName)
        {
            throw new Exception("ItemName field cannot be empty!");
        }

        if (notValidByPositivePrice)
        {
            throw new Exception("Price can only be positive!");
        }
        
        var desiredItem = await _repositoryManager.ItemRepository.GetByIdAsync(itemId);
        if (desiredItem is null)
            throw new ItemNotFoundException(itemId);
        var mappedAttachments = _mapper.Map<List<Attachment>>(item.Attachments);
        var mappedItemPhotos = _mapper.Map<List<ItemPhoto>>(item.ItemPhotos);
        var mappedDefects = _mapper.Map<List<Defect>>(item.Defects);
        var mappedComments = _mapper.Map<List<Comment>>(item.Comments);
        desiredItem.UpdateDate = DateTime.UtcNow;
        desiredItem.ItemName = item.ItemName;
        desiredItem.UserDate = notNullableUserDate;
        desiredItem.Status = item.Status;
        desiredItem.Price = item.Price;
        desiredItem.QRcode = item.QRcode;
        desiredItem.RoomId = item.RoomId;
        desiredItem.UserId = item.UserId;
        desiredItem.CurrentCategoryId = item.CurrentCategoryId;
        desiredItem.SetupId = item.SetupId;
        desiredItem.ItemPhotos = mappedItemPhotos;
        desiredItem.Attachments = mappedAttachments;
        desiredItem.Defects = mappedDefects;
        desiredItem.Comments = mappedComments;

        // await _repositoryManager.ItemRepository.Update(deciredItem);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();

        var result = _mapper.Map<ItemDto>(desiredItem);
        return result;
    }

    public async Task MoveItemsToAnotherRoom(Guid roomId, IList<ListItemsForUpdate> items)
    {
        var desiredRoom = await _repositoryManager.RoomRepository.GetByIdAsync(roomId);
        if (desiredRoom is null)
            throw new RoomNotFoundException(roomId);

        var itemsList = items.ToList();
        if (itemsList is not null)
        {
            foreach (var item in itemsList)
            {
                var findItem = await _repositoryManager.ItemRepository.GetByIdAsync(item.Id);
                if (findItem is null) continue;
                findItem.UpdateDate = DateTime.UtcNow;
                findItem.RoomId = roomId;
                findItem.SetupId = null;
                findItem.Setup = null;
                findItem.Status = StatusEnum.StatusType.Active;
                await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }
        }
    }

    public async Task<ItemDto> DeleteAsync(Guid id)
    {
        var item = await _repositoryManager.ItemRepository.GetByIdAsync(id);
        if (item is null)
            throw new ItemNotFoundException(id);

        _repositoryManager.ItemRepository.Remove(item);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();

        var result = _mapper.Map<ItemDto>(item);
        return result;
    }

    public async Task<bool> DeleteRange(IList<ItemsForRoom> items)
    {
        var mappedListItems = _mapper.Map<List<Item>>(items);
        _repositoryManager.ItemRepository.RemoveRange(mappedListItems);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return true;
    }
}