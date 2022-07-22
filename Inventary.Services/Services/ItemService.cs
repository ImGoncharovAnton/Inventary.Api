using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
using Inventary.Services.Extensions;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Services;

public class ItemService: IItemService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;


    public ItemService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IList<ItemDto>> GetAllItems()
    {
        var items = await _repositoryManager.ItemRepository.GetAllAsync();
        var result = _mapper.Map<List<ItemDto>>(items);
        return result;
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

    public async Task<ItemDto> UpdateAsync(Guid id, CreateItemDto item)
    {
        var deciredItem = await _repositoryManager.ItemRepository.GetByIdAsync(id);
        if (deciredItem is null)
            throw new ItemNotFoundException(id);

        var mappedItemPhotos = _mapper.Map<List<ItemPhoto>>(item.ItemPhotos);
        var mappedAttachments = _mapper.Map<List<Attachment>>(item.Attachments);
        var mappedDefects = _mapper.Map<List<Defect>>(item.Defects);
        var mappedComment = _mapper.Map<List<Comment>>(item.Comments);
        
        deciredItem.UpdateDate = DateTime.UtcNow;
        deciredItem.ItemName = item.ItemName;
        deciredItem.UserDate = item.UserDate;
        deciredItem.Status = item.Status;
        deciredItem.Price = item.Price;
        deciredItem.QRcode = item.QRcode;
        deciredItem.RoomId = item.RoomId;
        deciredItem.UserId = item.UserId;
        deciredItem.CurrentCategoryId = item.CurrentCategoryId;
        deciredItem.ItemPhotos = mappedItemPhotos;
        deciredItem.Attachments = mappedAttachments;
        deciredItem.Defects = mappedDefects;
        deciredItem.Comments = mappedComment;


        // await _repositoryManager.ItemRepository.Update(deciredItem);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();

        var result = _mapper.Map<ItemDto>(deciredItem);
        return result;
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
}