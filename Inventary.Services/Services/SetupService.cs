using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Domain.Enums;
using Inventary.Repositories.Common.Models;
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

    public async Task<IList<SetupsListWithNumberOfDefects>> GetAllWithNumberOfDefects()
    {
        return await _repositoryManager.SetupRepository.GetAllWithNumberOfDefects();
    }

    public async Task<IList<SetupsListWithNumberOfDefects>> GetAllSetupsForRoomById(Guid id)
    {
        return await _repositoryManager.SetupRepository.GetByIdWithSetups(id);
    }

    public async Task<SetupDto> GetByIdAsync(Guid id)
    {
        var setup = await _repositoryManager.SetupRepository.GetByIdWithItemsAsync(id);
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

        if (createItem.UserId.HasValue)
        {
            var findUser = await _repositoryManager.UserRepository.GetByIdAsync(createItem.UserId.Value);
            findUser.UpdateDate = DateTime.UtcNow;
            findUser.CurrentSetupId = newItem.Id;
        }
      
        
        var itemsList = createItem.Items;

        if (itemsList is not null)
        {
            foreach (var item in itemsList)
            {
                var findItem = await _repositoryManager.ItemRepository.GetByIdAsync(item.Id);
                if (findItem is null) continue;
                findItem.UpdateDate = DateTime.UtcNow;
                findItem.SetupId = newItem.Id;
                findItem.Status = StatusEnum.StatusType.Active;
                await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }
        }

        var result = _mapper.Map<SetupDto>(newItem);
        return result;
    }

    public async Task UpdateAsync(Guid id, UpdateSetupDto item)
    {
        var desiredItem = await _repositoryManager.SetupRepository.GetByIdWithItemsAsync(id);
        if (desiredItem is null)
            throw new SetupNotFoundException(id);
        desiredItem.UpdateDate = DateTime.UtcNow;
        desiredItem.SetupName = item.SetupName;
        desiredItem.Status = item.Status;

        if (desiredItem.UserId != item.UserId)
        {
            if (desiredItem.UserId.HasValue)
            {
                var findOldUser = await _repositoryManager.UserRepository.GetByIdAsync(desiredItem.UserId.Value);
                findOldUser.UpdateDate = DateTime.UtcNow;
                findOldUser.CurrentSetupId = null;
            }

            if (item.UserId.HasValue)
            {
                var findUser = await _repositoryManager.UserRepository.GetByIdAsync(item.UserId.Value);
                findUser.UpdateDate = DateTime.UtcNow;
                findUser.CurrentSetupId = id;
            }
            desiredItem.UserId = item.UserId;
        }
        
        
        
        var mappedItems = _mapper.Map<List<CreateItemWithSetupDto>>(desiredItem.Items);
        
        var exceptItemsList = mappedItems
            .ExceptBy(item.Items.Select(x => x.Id), z => z.Id).ToList();

        var newItemsList = item.Items
            .ExceptBy(mappedItems.Select(x => x.Id), z => z.Id).ToList();
        foreach (var exceptItem in exceptItemsList)
        {
            var findItem = await _repositoryManager.ItemRepository.GetByIdAsync(exceptItem.Id);
            if (findItem is null) continue;
            findItem.UpdateDate = DateTime.UtcNow;
            findItem.SetupId = null;
            findItem.Status = StatusEnum.StatusType.Inactive;
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
        
        var itemsList = item.Items;

        if (itemsList is not null)
        {
            foreach (var el in newItemsList)
            {
                var findItem = await _repositoryManager.ItemRepository.GetByIdAsync(el.Id);
                if (findItem is null) continue;
                findItem.UpdateDate = DateTime.UtcNow;
                findItem.SetupId = id;
                findItem.Status = StatusEnum.StatusType.Active;
            }
        }

        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var setup = await _repositoryManager.SetupRepository.GetByIdWithItemsAsync(id);
        if (setup is null)
            throw new SetupNotFoundException(id);
        var itemsList = setup.Items;
        if (itemsList is not null)
        {
            foreach (var item in itemsList)
            {
                var findItem = await _repositoryManager.ItemRepository.GetByIdAsync(item.Id);
                if (findItem is null) continue;
                findItem.UpdateDate = DateTime.UtcNow;
                findItem.Status = StatusEnum.StatusType.Inactive;
                findItem.RoomId = null;
                findItem.Room = null;
                findItem.UserId = null;
            }
        }
        
        _repositoryManager.SetupRepository.Remove(setup);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }
}