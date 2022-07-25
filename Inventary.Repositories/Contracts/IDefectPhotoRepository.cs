using Inventary.Domain.Entities;

namespace Inventary.Repositories.Contracts;

public interface IDefectPhotoRepository: IGenericRepository<DefectPhoto>
{
    void AddRange(List<DefectPhoto> entity);

}