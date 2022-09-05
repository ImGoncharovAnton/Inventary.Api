using FluentAssertions;
using Inventary.Repositories;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Contracts;
using Inventary.Services.Extensions;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Inventary.Tests.MockData;
using Microsoft.Extensions.DependencyInjection;

namespace Inventary.Tests.Services;

public class CategoryServiceTest : IClassFixture<DependencyCategoryFixture>
{
    private readonly ServiceProvider _serviceProvider;

    public CategoryServiceTest(DependencyCategoryFixture fixture)
    {
        _serviceProvider = fixture.ServiceProvider;
    }

    [Fact]
    public async Task GetAllWithItemsAsync_ReturnCategoryList()
    {
        // Arrange
        var sut = GetCategoryService(_serviceProvider);

        // Act
        var result = await sut.GetAllWithItemsAsync();

        // Assert
        result.Should().NotBeNullOrEmpty().And.BeOfType<List<CategoriesForRoom>>();
    }

    [Fact]
    public async Task GetAllCategoriesBySetupId_isValidSetupId_ReturnCategoryList()
    {
        // Arrange
        var setupId = new Guid("489FB9AA-471F-41FE-B591-A4C27246BB08");
        var sut = GetCategoryService(_serviceProvider);

        // Act
        var result = await sut.GetAllCategoriesBySetupId(setupId);

        // Assert
        result.Should().NotBeNull().And.BeOfType<List<CategoriesForRoom>>();
    }
    
    [Fact]
    public async Task GetAllCategoriesBySetupId_isNotValidSetupId_ShouldException()
    {
        // Arrange
        var setupId = new Guid("D1CDAB11-98B0-461F-8677-7B4E2193B2BA");
        var sut = GetCategoryService(_serviceProvider);
       
        // Act
        var exception = await Assert.ThrowsAsync<Exception>(() =>
            sut.GetAllCategoriesBySetupId(setupId));

        // Assert
        exception.Should().NotBeNull().And.Match<Exception>(x => 
            x.Message == "Setup is not found!");
    }

    [Fact]
    public async Task GetByIdAsync_IsValidValue_ReturnCategory()
    {
        // Arrange
        var categoryId = new Guid("CE126C08-BBD1-47E2-AF5A-3E095DA89DDE");
        var sut = GetCategoryService(_serviceProvider);

        // Act
        var result = await sut.GetByIdAsync(categoryId);

        // Assert
        result.Should().NotBeNull().And.BeOfType<CategoryDto>();
    }

    [Fact]
    public async Task GetByIdAsync_IsNotValidValue_ShouldThrowNotFoundException()
    {
        // Arrange
        var categoryId = new Guid("3BD69278-88A6-4D45-9D8A-9CA9F83B5C93");
        var sut = GetCategoryService(_serviceProvider);

        // Act
        var exception = await Assert.ThrowsAsync<CategoryNotFoundException>(() => 
            sut.GetByIdAsync(categoryId));

        // Assert
        exception.Should().NotBeNull().And.Match<CategoryNotFoundException>(x =>
            x.Message == $"The category with the identifier {categoryId} was not found.");
    }

    [Fact]
    public async Task CreateRangeAsync_IsValidCategoryList_ReturnTrue()
    {
        // Arrange
        var sut = GetCategoryService(_serviceProvider);

        // Act
        var result = await sut.CreateRangeAsync(CategoryMockData.CreateListCategoryDto());
        var newCategoryList = await sut.GetAllWithItemsAsync();

        // Assert
        result.Should().BeTrue();
        newCategoryList.Count.Should().NotBe(5);
    }

    [Fact]
    public async Task UpdateAsync_IsValidIdAndModel_ReturnTrue()
    {
        // Arrange
        var categoryItem = CategoryMockData.CreateCategoryDto();
        var categoryId = new Guid("6F595167-0848-490B-B705-A302B12DBD77");
        var sut = GetCategoryService(_serviceProvider);
        
        // Act 
        var result = await sut.UpdateAsync(categoryId, categoryItem);

        // Assert
        result.Should().BeTrue();
    }
    
    [Fact]
    public async Task UpdateAsync_IsNotValidId_ReturnTrue()
    {
        // Arrange
        var categoryItem = CategoryMockData.CreateCategoryDto();
        var categoryId = new Guid("AE92D7C5-D1CC-4796-B2A7-24EEDB9614A5");
        var sut = GetCategoryService(_serviceProvider);
        
        // Act 
        var exception = await Assert.ThrowsAsync<CategoryNotFoundException>(() =>
            sut.UpdateAsync(categoryId, categoryItem));
        
        // Assert
        exception.Should().NotBeNull().And.Match<CategoryNotFoundException>(x => 
            x.Message == $"The category with the identifier {categoryId} was not found.");
    }
    
   [Fact]
    public async Task DeleteAsync_IsValidCategoryId_ReturnTrue()
    {
        // Arrange
        var categoryId = new Guid("B9EA7A35-57C2-4D95-A18D-3C490881A2A2");
        var sut = GetCategoryService(_serviceProvider);
        
        // Act
        var result = await sut.DeleteAsync(categoryId);
        var categoryList = await sut.GetAllWithItemsAsync();

        // Assert
        result.Should().BeTrue();
        categoryList.Count.Should().NotBe(5);
    }
    
    [Fact]
    public async Task DeleteAsync_IsNotValidCategoryId_ShouldThrowCategoryNotFoundException()
    {
        // Arrange
        var categoryId = new Guid("FE19FD00-7916-4AE6-86CA-42985EDECB42");
        var sut = GetCategoryService(_serviceProvider);

        // Act
        var exception = await Assert.ThrowsAsync<CategoryNotFoundException>(() =>
            sut.DeleteAsync(categoryId));

        // Assert
        exception.Should().NotBeNull().And.Match<CategoryNotFoundException>(x => x.Message == $"The category with the identifier {categoryId} was not found.");
    }



    private ICategoryService GetCategoryService(IServiceProvider scope)
    {
        return scope.GetService<IServiceManager>()!.CategoryService;
    }
}