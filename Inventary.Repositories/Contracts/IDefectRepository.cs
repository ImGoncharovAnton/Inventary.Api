using Inventary.Domain.Entities;

namespace Inventary.Repositories.Contracts;

public interface IDefectRepository: IGenericRepository<Defect>
{
    Task<Defect> AddAsync(Defect entity);
}