using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Repositories.Repositories;

public class ItemPhotoRepository: GenericRepository<ItemPhoto>, IItemPhotoRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ItemPhotoRepository(ApplicationDbContext dbContext): base(dbContext)
    {
        _dbContext = dbContext;
    }

    
    
    public void Upsert(ItemPhoto entity)
    {
       _dbContext.ChangeTracker.TrackGraph(entity, e =>
       {
           e.Entry.State = e.Entry.IsKeySet ? EntityState.Unchanged : EntityState.Added;
       });
       
#if DEBUG
       foreach (var entry in _dbContext.ChangeTracker.Entries())
       {
           Console.WriteLine($"Entity: {entry.Entity.GetType().Name} State: {entry.State.ToString()}");
       }
#endif
    }
    
}