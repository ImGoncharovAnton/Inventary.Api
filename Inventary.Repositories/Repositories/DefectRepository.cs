using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;

namespace Inventary.Repositories.Repositories;

public class DefectRepository: GenericRepository<Defect>, IDefectRepository
{
    private readonly ApplicationDbContext _dbContext;
    public DefectRepository(ApplicationDbContext dbContext): base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Defect> AddAsync(Defect entity)
    {
        await _dbContext.Defects.AddAsync(entity);
        return entity;
    }
}