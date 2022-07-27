using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;

namespace Inventary.Repositories.Contracts;

public interface ISetupRepository: IGenericRepository<Setup>
{
    Task<Setup> AddAsync(Setup entity);
    Task<Setup> GetByIdWithItemsAsync(Guid id);
    Task<List<SetupsListWithNumberOfDefects>> GetAllWithNumberOfDefects();
    Task<List<SetupsListWithNumberOfDefects>> GetByIdWithSetups(Guid id);
}