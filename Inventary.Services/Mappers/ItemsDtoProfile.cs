using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Mappers;

public class ItemsDtoProfile : Profile
{
    public ItemsDtoProfile()
    {
        CreateMap<Item, ItemDto>().ReverseMap();
        CreateMap<CreateItemDto, Item>();
        CreateMap<ItemPhoto, ItemPhotoDto>().ReverseMap();
        CreateMap<CreateItemPhotoDto, ItemPhoto>();
    }
}