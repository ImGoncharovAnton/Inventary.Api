using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Mappers;

public class ItemPhotoDtoProfile : Profile
{
    public ItemPhotoDtoProfile()
    {
        CreateMap<ItemPhoto, ItemPhotoDto>().ReverseMap();
        CreateMap<CreateItemPhotoDto, ItemPhoto>();
    }
}