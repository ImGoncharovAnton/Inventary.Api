using Inventary.Repositories.Common.Models;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface ICategoryService
{
    Task<IList<CategoryDto>> GetAllAsync();
    Task<IList<CategoriesForRoom>> GetAllWithItemsAsync();
    Task<CategoryDto> GetByIdAsync(Guid id);
    Task<CategoryDto> CreateAsync(CreateCategoryDto createCategory);
    Task CreateRangeAsync(IList<CreateCategoryDto> createCategoryList);
    Task UpdateAsync(Guid id, CreateCategoryDto updateCategory);
    Task DeleteAsync(Guid id);
}