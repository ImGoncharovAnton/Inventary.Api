using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Services;

public class ItemPhotoService : IItemPhotoService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public ItemPhotoService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IList<ItemPhotoDto>> GetAllAsync()
    {
        var items = await _repositoryManager.ItemPhotoRepository.GetAllAsync();
        var result = _mapper.Map<List<ItemPhotoDto>>(items);
        return result;
    }

    public async Task<ItemPhotoDto> GetByIdAsync(Guid id)
    {
        var item = await _repositoryManager.ItemPhotoRepository.GetByIdAsync(id);
        if (item is null)
            throw new Exception("ItemPhoto with not founded");
        var result = _mapper.Map<ItemPhotoDto>(item);
        return result;
    }

    public async Task<ItemPhotoDto> CreateAsync(CreateItemPhotoDto itemPhoto)
    {
        var item = _mapper.Map<ItemPhoto>(itemPhoto);
        var result = _mapper.Map<ItemPhotoDto>(item);
        
        _repositoryManager.ItemPhotoRepository.Add(item);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return result;
    }

    public async Task UpdateAsync(Guid id, CreateItemPhotoDto itemPhoto)
    {
        var deciredItem = await _repositoryManager.ItemPhotoRepository.GetByIdAsync(id);
        if (deciredItem is null)
            throw new Exception("ItemPhoto not found");
        
        deciredItem.UpdateDate = DateTime.UtcNow;
        deciredItem.OrigUrl = itemPhoto.OrigUrl;
        
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var item = await _repositoryManager.ItemPhotoRepository.GetByIdAsync(id);
        if (item is null)
            throw new Exception("ItemPhoto is not found");
        
        _repositoryManager.ItemPhotoRepository.Remove(item);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }
}