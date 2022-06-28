using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Response;

namespace Inventary.Web.Mappers;

public class RoomsUiProfile : Profile
{
    public RoomsUiProfile()
    {
        CreateMap<RoomDto, RoomUIResponse>();
    }
    
}