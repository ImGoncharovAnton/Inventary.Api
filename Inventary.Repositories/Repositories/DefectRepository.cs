using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;

namespace Inventary.Repositories.Repositories;

public class DefectRepository: GenericRepository<Defect>, IDefectRepository
{
    public DefectRepository(ApplicationDbContext dbContext): base(dbContext)
    {
        
    }
}