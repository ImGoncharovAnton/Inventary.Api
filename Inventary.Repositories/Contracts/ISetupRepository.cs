using Inventary.Domain.Entities;

namespace Inventary.Repositories.Contracts;

public interface ISetupRepository: IGenericRepository<Setup>
{
    Task<Setup> AddAsync(Setup entity);
    Task<Setup> GetByIdWithItemsAsync(Guid id);
}