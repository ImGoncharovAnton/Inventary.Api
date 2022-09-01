using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;

namespace Inventary.Repositories.Contracts;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<List<CategoriesForRoom>> GetAllWithNumbersOfItems();
    Task<List<CategoriesForRoom>> GetCategoryListBySetupId(Guid setupId);
    Task AddRange(IList<Category> categories);

}