using AutoMapper;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;

namespace Inventary.Web.Mappers;

public class CategoryUiProfile : Profile
{
    public CategoryUiProfile()
    {
        CreateMap<CategoryDto, CategoryResponseUi>();
        CreateMap<CategoryRequestUi, CreateCategoryDto>();
    }
}