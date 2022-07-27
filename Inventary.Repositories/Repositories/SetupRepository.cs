using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Setup> GetByIdWithItemsAsync(Guid id)
    {
        var result = await _dbContext.Setups
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<List<SetupsListWithNumberOfDefects>> GetAllWithNumberOfDefects()
    {
        var setups = _dbContext.Setups
            .Select(x => new SetupsListWithNumberOfDefects()
            {
                Id = x.Id,
                SetupName = x.SetupName,
                Status = x.Status,
                UserId = x.UserId,
                NumberOfDefects = x.Items.SelectMany(z => z.Defects).Count()
            }).ToListAsync();
        return await setups;
    }
}