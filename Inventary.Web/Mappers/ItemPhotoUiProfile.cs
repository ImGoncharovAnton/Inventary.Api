using AutoMapper;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;

namespace Inventary.Web.Mappers;

public class ItemPhotoUiProfile: Profile
{
    public ItemPhotoUiProfile()
    {
        CreateMap<ItemPhotoDto, ItemPhotoResponseUi>();
        CreateMap<ItemPhotoRequestUi, CreateItemPhotoDto>();
    }
}