using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Mappers;

public class RoomsDtoProfile : Profile
{
    public RoomsDtoProfile()
    {
        // CreateMap<RoomEntity, RoomDTO>().ReverseMap();
        CreateMap<Room, RoomDto>().ReverseMap();
        CreateMap<CreateRoomDTO, Room>();
    }
}