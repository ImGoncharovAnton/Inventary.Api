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


    public async Task<List<CategoriesForRoom>> GetAllWithNumbersOfItems()
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

    public async Task<List<CategoriesForRoom>> GetCategoryListBySetupId(Guid setupId)
    {
        var findSetup = await _dbContext.Setups.FirstOrDefaultAsync(x => x.Id == setupId);
        if (findSetup is null)
            throw new Exception("Setup is not found!");
        var setup = await _dbContext.Setups
            .Include(x => x.Items)
            .ThenInclude(x => x.Category)
            .Where(s => s.Id == setupId)
            .ToListAsync();

        var getCategories = setup.SelectMany(x => x.Items
            .Where(z => z.CurrentCategoryId != null).Select(z => z.Category)).Distinct().ToList();

        var result = getCategories.Select(c => new CategoriesForRoom()
        {
            Id = c.Id,
            CategoryName = c.CategoryName,
            NumbersOfItems = c.Items.Count()
        }).ToList();
            
        return result;
    }

    public async Task AddRange(IList<Category> categories)
    {
        await _dbContext.Categories.AddRangeAsync(categories);
    }
}