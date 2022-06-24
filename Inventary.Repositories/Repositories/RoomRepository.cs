using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;

namespace Inventary.Repositories.Repositories;

public class RoomRepository : GenericRepository<RoomEntity>, IRoomRepository
{
    public RoomRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        
    }
}