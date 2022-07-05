using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Repositories.Repositories;

public class ItemRepository: IItemRepository<Item>
{
    private readonly ApplicationDbContext _dbContext;


    public ItemRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IList<Item>> GetAllAsync()
    {
        return await _dbContext.Set<Item>().ToListAsync();
    }

    public async Task<Item> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<Item>().FindAsync(id);
    }

    public async Task<Item> Add(Item entity)
    {
        await _dbContext.Set<Item>().AddAsync(entity);
        return entity;
    }

    public Item Remove(Item entity)
    {
         _dbContext.Set<Item>().Remove(entity);
         return entity;
    }
}