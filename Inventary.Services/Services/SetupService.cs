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
            
        }
        
    }

    public async Task UpdateAsync(Guid id, UpdateSetupDto item)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}