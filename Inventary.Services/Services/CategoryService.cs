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

    public async Task<IList<CategoryDto>> GetAllAsync()
    {
        var categories = await _repositoryManager.CategoryRepository.GetAllAsync();
        var result = _mapper.Map<List<CategoryDto>>(categories);
        return result;
    }

    public async Task<IList<CategoriesForRoom>> GetAllWithItemsAsync()
    {
        return await _repositoryManager.CategoryRepository.GetAllWithItems();
    }

    public async Task<CategoryDto> GetByIdAsync(Guid id)
    {
        var category = await _repositoryManager.CategoryRepository.GetByIdAsync(id);
        if (category is null)
            throw new CategoryNotFoundException(id);
        var result = _mapper.Map<CategoryDto>(category);
        return result;
    }

    public async Task<CategoryDto> CreateAsync(CreateCategoryDto createCategory)
    {
        var category = _mapper.Map<Category>(createCategory);
        var result = _mapper.Map<CategoryDto>(category);
        
        _repositoryManager.CategoryRepository.Add(category);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return result;
    }

    public async Task UpdateAsync(Guid id, CreateCategoryDto updateCategory)
    {
        var deciredCategory = await _repositoryManager.CategoryRepository.GetByIdAsync(id);
        if (deciredCategory is null)
            throw new CategoryNotFoundException(id);

        deciredCategory.CategoryName = updateCategory.CategoryName;
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await _repositoryManager.CategoryRepository.GetByIdAsync(id);
        if (category is null)
            throw new CategoryNotFoundException(id);
        
        _repositoryManager.CategoryRepository.Remove(category);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }
}