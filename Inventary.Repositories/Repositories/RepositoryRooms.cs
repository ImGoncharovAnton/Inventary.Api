using Inventary.Domain.Entities;
using Inventary.Domain.Extensions;
using Inventary.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Repositories.Repositories;

public class RepositoryRooms<T>: IRepositoryRooms<T> where T: BaseEntity
{
    private readonly ApplicationDbContext _dbContext;
    private DbSet<T> _entities;

    public RepositoryRooms(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = _dbContext.Set<T>();
    }

    public IEnumerable<T> GetAll()
    // public IList<T> GetAll()
    {
        return _entities.ToList();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _entities.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Insert(T entity)
    {

        _entities.Add(entity);
    }

    public void Remove(T entity)
    {
    
        _entities.Remove(entity);
    }
    
}