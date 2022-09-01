using AutoFixture;
using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Models.DTO;

namespace Inventary.Tests.MockData;

public class CategoryMockData
{
    public static List<Category> GetCategories()
    {
        return new List<Category>
        {
            new Category
            {
                Id = new Guid("B337CAFE-996E-449A-AAD8-186B9D615BFA"),
                CategoryName = "Category 1",
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Items = null
            },
            new Category
            {
                Id = new Guid("FC7FE539-AB73-46A6-A5E8-A4CDDFB518A0"),
                CategoryName = "Category 2",
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Items = null
            },
            new Category
            {
                Id = new Guid("CE126C08-BBD1-47E2-AF5A-3E095DA89DDE"),
                CategoryName = "Category 3",
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Items = null
            },
            new Category
            {
                Id = new Guid("6F595167-0848-490B-B705-A302B12DBD77"),
                CategoryName = "Category 4",
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Items = null
            },
            new Category
            {
                Id = new Guid("29377380-905A-41C7-A70C-C062F9882D5A"),
                CategoryName = "Category 5",
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Items = null
            }
        };
    }

    public static List<Category> GetEmptyCategories()
    {
        return new List<Category>();
    }
    
    public static CreateCategoryDto CreateCategoryDto()
    {
        var fixture = new Fixture();
        var category = fixture.Create<CreateCategoryDto>();
        return category;
    }

    public static List<CreateCategoryDto> CreateListCategoryDto()
    {
        var fixture = new Fixture();
        var categories = fixture.CreateMany<CreateCategoryDto>().ToList();
        return categories;
    }
    
    public static List<CreateCategoryDto> CreateListCategoryWithEmptyCategoryName()
    {
        return new List<CreateCategoryDto>
        {
            new CreateCategoryDto
            {
                CategoryName = "Category 6",
            },
            new CreateCategoryDto
            {
                CategoryName = "",
            }
        };
    }
}