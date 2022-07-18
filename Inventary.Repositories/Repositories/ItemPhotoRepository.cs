using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;

namespace Inventary.Repositories.Repositories;

public class ItemPhotoRepository: GenericRepository<ItemPhoto>, IItemPhotoRepository
{
    public ItemPhotoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        
    }
}