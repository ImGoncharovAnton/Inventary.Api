using AutoMapper;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;

namespace Inventary.Web.Mappers;

public class ItemsUiProfile: Profile
{
    public ItemsUiProfile()
    {
        CreateMap<ItemDto, ItemResponseUi>();
        CreateMap<ItemRequestUi, CreateItemDto>();
    }
}