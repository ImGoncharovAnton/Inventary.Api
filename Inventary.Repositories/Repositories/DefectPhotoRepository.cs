using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;

namespace Inventary.Repositories.Repositories;

public class DefectPhotoRepository: GenericRepository<DefectPhoto>, IDefectPhotoRepository
{
    private readonly ApplicationDbContext _dbContext;
    public DefectPhotoRepository(ApplicationDbContext dbContext): base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async void AddRange(List<DefectPhoto> entity)
    {
        await _dbContext.DefectPhotos.AddRangeAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
}