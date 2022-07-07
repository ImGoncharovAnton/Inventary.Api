using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Repositories.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    public CategoryRepository(ApplicationDbContext dbContext): base(dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<CategoriesForRoom>> GetAllWithItems()
    {
        var category = _dbContext.Categories
            .Select(x => new CategoriesForRoom()
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                NumbersOfItems = x.Items.Count
            }).ToListAsync();
        return await category;

    }
}