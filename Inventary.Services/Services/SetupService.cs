using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
using Inventary.Services.Extensions;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Services;

public class SetupService: ISetupService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public SetupService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IList<SetupDto>> GetAllItems()
    {
        var setups = await _repositoryManager.SetupRepository.GetAllAsync();
        var result = _mapper.Map<List<SetupDto>>(setups);
        return result;
    }

    public async Task<SetupDto> GetByIdAsync(Guid id)
    {
        var setup = await _repositoryManager.SetupRepository.GetByIdAsync(id);
        if (setup is null)
            throw new SetupNotFoundException(id);
        var result = _mapper.Map<SetupDto>(setup);
        return result;
    }

    public async Task<SetupDto> CreateAsync(CreateSetupDto createItem)
    {
        var mappedItem = new Setup()
        {
            CreatedDate = DateTime.UtcNow,
            UpdateDate = DateTime.UtcNow,
            SetupName = createItem.SetupName,
            Status = createItem.Status,
            UserId = createItem.UserId
        };
        var newItem = await _repositoryManager.SetupRepository.AddAsync(mappedItem);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();

        var itemsList = createItem.Items;

        if (itemsList is not null)
        {
            foreach (var item in itemsList)
            {
                var findItem = await _repositoryManager.ItemRepository.GetByIdAsync(item.Id);
                if (findItem is null) continue;
                findItem.UpdateDate = DateTime.UtcNow;
                findItem.SetupId = newItem.Id;
                await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }
        }

        var result = _mapper.Map<SetupDto>(newItem);
        return result;
    }

    public async Task UpdateAsync(Guid id, UpdateSetupDto item)
    {
        var desiredItem = await _repositoryManager.SetupRepository.GetByIdAsync(id);
        if (desiredItem is null)
            throw new SetupNotFoundException(id);
        desiredItem.UpdateDate = DateTime.UtcNow;
        desiredItem.SetupName = item.SetupName;
        desiredItem.Status = item.Status;
        desiredItem.UserId = item.UserId;

        var mappedItems = _mapper.Map<List<Item>>(item.Items);

        var exceptItemsList = desiredItem.Items
            .ExceptBy(mappedItems.Select(x => x.Id), z => z.Id).ToList();
        foreach (var exceptItem in exceptItemsList)
        {
            var findItem = await _repositoryManager.ItemRepository.GetByIdAsync(exceptItem.Id);
            if (findItem is null) continue;
            findItem.UpdateDate = DateTime.UtcNow;
            findItem.SetupId = null;
        }


        foreach (var mappedItem in mappedItems)
        {
            var findItem = await _repositoryManager.ItemRepository.GetByIdAsync(mappedItem.Id);
            if (findItem is null) continue;
            findItem.UpdateDate = DateTime.UtcNow;
            findItem.SetupId = mappedItem.SetupId;
        }
        
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {

        var setup = await _repositoryManager.SetupRepository.GetByIdAsync(id);
        if (setup is null)
            throw new SetupNotFoundException(id);
        
        _repositoryManager.SetupRepository.Remove(setup);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }
}