using AutoMapper;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;

namespace Inventary.Web.Mappers;

public class UsersUiProfile : Profile
{
    public UsersUiProfile()
    {
        CreateMap<UserDto, UserResponseUi>();
        CreateMap<UserRequestUi, UserCreateDto>();
    }
}