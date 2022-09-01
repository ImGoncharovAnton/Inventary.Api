using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
using Inventary.Services.Extensions;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    
    public CategoryService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IList<CategoriesForRoom>> GetAllWithItemsAsync()
    {
        return await _repositoryManager.CategoryRepository.GetAllWithNumbersOfItems();
    }

    public async Task<IList<CategoriesForRoom>> GetAllCategoriesBySetupId(Guid id)
    {
        return await _repositoryManager.CategoryRepository.GetCategoryListBySetupId(id);
    }

    public async Task<CategoryDto> GetByIdAsync(Guid id)
    {
        var category = await _repositoryManager.CategoryRepository.GetByIdAsync(id);
        if (category is null)
            throw new CategoryNotFoundException(id);
        var result = _mapper.Map<CategoryDto>(category);
        return result;
    }

    public async Task<bool> CreateRangeAsync(IList<CreateCategoryDto> createCategoryList)
    {
        var checkValid = createCategoryList.Any(c => c.CategoryName == String.Empty);
        if (!checkValid)
        {
            var mappedList = _mapper.Map<List<Category>>(createCategoryList);
            await _repositoryManager.CategoryRepository.AddRange(mappedList);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return true;
        }
        else
        {
            throw new Exception("CategoryName field cannot be empty");
            
        }
    }

    public async Task<bool> UpdateAsync(Guid id, CreateCategoryDto updateCategory)
    {
        var validateItem = updateCategory.CategoryName == String.Empty;
        if (validateItem)
            throw new Exception("CategoryName field cannot be empty");
        var deciredCategory = await _repositoryManager.CategoryRepository.GetByIdAsync(id);
        if (deciredCategory is null)
            throw new CategoryNotFoundException(id);

        deciredCategory.CategoryName = updateCategory.CategoryName;
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var category = await _repositoryManager.CategoryRepository.GetByIdAsync(id);
        if (category is null)
            throw new CategoryNotFoundException(id);
        
        _repositoryManager.CategoryRepository.Remove(category);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return true;
    }
}