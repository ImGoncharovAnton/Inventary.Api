using AutoMapper;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;

namespace Inventary.Web.Mappers;

public class SetupUiProfile: Profile
{
    public SetupUiProfile()
    {
        CreateMap<SetupDto, SetupResponseUi>();
        CreateMap<SetupRequestUi, CreateSetupDto>();
        CreateMap<SetupUpdateRequestUi, UpdateSetupDto>();

        CreateMap<ItemDto, ItemForSetupsResponseUi>();
        CreateMap<ItemForSetupsRequestUi, CreateItemWithSetupDto>().ReverseMap();
        
    }
}