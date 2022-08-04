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

    public async Task<IList<ItemsList>> GetItemsListAsync()
    {
        return await _repositoryManager.ItemRepository.GetListItemsAsync();
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
        var item = _mapper.Map<Item>(createItem);

        var result = _mapper.Map<ItemDto>(item);

        await _repositoryManager.ItemRepository.Add(item);

        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return result;
    }

    public async Task<ItemDto> UpdateAsync(Guid id, UpdateItemDto item)
    {
        var desiredItem = await _repositoryManager.ItemRepository.GetByIdAsync(id);
        if (desiredItem is null)
            throw new ItemNotFoundException(id);
        var mappedAttachments = _mapper.Map<List<Attachment>>(item.Attachments);
        var mappedItemPhotos = _mapper.Map<List<ItemPhoto>>(item.ItemPhotos);
        var mappedDefects = _mapper.Map<List<Defect>>(item.Defects);
        var mappedComments = _mapper.Map<List<Comment>>(item.Comments);
        desiredItem.UpdateDate = DateTime.UtcNow;
        desiredItem.ItemName = item.ItemName;
        desiredItem.UserDate = item.UserDate;
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

    public async Task MoveItemsToAnotherRoom(Guid id, IList<ListItemsForUpdate> items)
    {
        var desiredRoom = await _repositoryManager.RoomRepository.GetByIdAsync(id);
        if (desiredRoom is null)
            throw new RoomNotFoundException(id);

        var itemsList = items.ToList();
        // Можно ли это оптимизировать? Мб отправлять массив на апдейт? И как тогда менять значения...
        if (itemsList is not null)
        {
            foreach (var item in itemsList)
            {
                var findItem = await _repositoryManager.ItemRepository.GetByIdAsync(item.Id);
                if (findItem is null) continue;
                findItem.UpdateDate = DateTime.UtcNow;
                findItem.RoomId = id;
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
    
    public async Task DeleteRange(IList<ItemsForRoom> items)
    {
        var mappedListItems = _mapper.Map<List<Item>>(items);
        _repositoryManager.ItemRepository.RemoveRange(mappedListItems);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }
}