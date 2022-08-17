using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;

namespace Inventary.Repositories.Contracts;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<List<CategoriesForRoom>> GetAllWithItems();
    Task<List<CategoriesForRoom>> GetCategoryBySetupId(Guid setupId);
    Task AddRange(IList<Category> categories);

}