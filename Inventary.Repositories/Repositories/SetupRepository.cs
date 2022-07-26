using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;

namespace Inventary.Repositories.Repositories;

public class SetupRepository: GenericRepository<Setup>, ISetupRepository
{
    private readonly ApplicationDbContext _dbContext;
    public SetupRepository(ApplicationDbContext dbContext): base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Setup> AddAsync(Setup entity)
    {
        await _dbContext.Setups.AddAsync(entity);
        return entity;
    }
}