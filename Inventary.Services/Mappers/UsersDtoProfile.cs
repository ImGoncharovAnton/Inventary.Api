using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Mappers;

public class UsersDtoProfile : Profile
{
    public UsersDtoProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<UserCreateDto, User>();
    }
}