using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface ICategoryService
{
    Task<IList<CategoriesForRoom>> GetAllWithItemsAsync();
    Task<IList<CategoriesForRoom>> GetAllCategoriesBySetupId(Guid id);
    Task<CategoryDto> GetByIdAsync(Guid id);
    Task<bool> CreateRangeAsync(IList<CreateCategoryDto> createCategoryList);
    Task<bool> UpdateAsync(Guid id, CreateCategoryDto updateCategory);
    Task<bool> DeleteAsync(Guid id);
}