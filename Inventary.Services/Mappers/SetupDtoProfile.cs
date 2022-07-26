using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Mappers;

public class SetupDtoProfile: Profile
{
    public SetupDtoProfile()
    {
        CreateMap<Setup, SetupDto>().ReverseMap();
        CreateMap<CreateSetupDto, Setup>();
        CreateMap<UpdateSetupDto, Setup>();

        CreateMap<CreateItemWithSetupDto, Item>();
        CreateMap<Item, ItemDto>().ReverseMap();

    }
}