using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Mappers;

public class RoomsDTOProfile : Profile
{
    public RoomsDTOProfile()
    {
        CreateMap<RoomEntity, RoomDTO>().ReverseMap();
    }
}