using AutoMapper;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;

namespace Inventary.Web.Mappers;

public class SetupUiProfile: Profile
{
    public SetupUiProfile()
    {
        CreateMap<SetupDto, SetupResponseUi>()
            .ForMember(dest => dest.UserFullName, opt =>
                opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
        CreateMap<SetupRequestUi, CreateSetupDto>();
        CreateMap<SetupUpdateRequestUi, UpdateSetupDto>();

        CreateMap<ItemDto, ItemForSetupsResponseUi>()
            .ForMember(dest => dest.Date, opt => 
                opt.MapFrom(src => src.UserDate))
            .ForMember(dest => dest.RoomName, opt => 
                opt.MapFrom(src => src.Room.RoomName))
            .ForMember(dest => dest.CategoryId, opt =>
                opt.MapFrom(src => src.CurrentCategoryId))
            .ForMember(dest => dest.NumberOfDefects, opt =>
                opt.MapFrom(src => src.Defects.Count));
        CreateMap<ItemForSetupsRequestUi, CreateItemWithSetupDto>().ReverseMap();
        
    }
}