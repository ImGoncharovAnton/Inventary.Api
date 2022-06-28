using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Mappers;

public class UsersDTOProfile : Profile
{
    public UsersDTOProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<UserCreateDto, User>();
    }
}