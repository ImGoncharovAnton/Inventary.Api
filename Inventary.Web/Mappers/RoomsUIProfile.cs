using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Web.Models.Response;

namespace Inventary.Web.Mappers;

public class RoomsUIProfile : Profile
{
    public RoomsUIProfile()
    {
        CreateMap<RoomEntity, RoomUIResponse>();
    }
    
}