using Inventary.Domain.Entities;
using Inventary.Domain.Extensions;
using Inventary.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Repositories.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _dbContext;

    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public void Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
    }

    public void Remove(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }
}