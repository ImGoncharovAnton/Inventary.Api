using AutoMapper;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;

namespace Inventary.Web.Mappers;

public class ItemsUiProfile: Profile
{
    public ItemsUiProfile()
    {
        CreateMap<ItemDto, ItemResponseUi>()
            .ForMember(dest => dest.RoomName, o => 
                o.MapFrom(src => src.Room.RoomName))
            .ForMember(dest => dest.CategoryName, o => 
                o.MapFrom(src => src.Category.CategoryName))
            .ForMember(dest => dest.SetupName, o => 
                o.MapFrom(src => src.Setup.SetupName))
            .ForMember(dest => dest.UserName, o => 
                o.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
        CreateMap<ItemRequestUi, CreateItemDto>();
        CreateMap<ItemUpdateRequestUi, UpdateItemDto>();
        
        CreateMap<ItemPhotoDto, ItemPhotoResponseUi>();
        CreateMap<ItemPhotoRequestUi, CreateItemPhotoDto>();
        CreateMap<ItemPhotoUpdateRequestUi, UpdateItemPhotoDto>();
        
        CreateMap<AttachmentDto, AttachmentResponseUi>();
        CreateMap<AttachmentRequestUi, CreateAttachementDto>();
        CreateMap<AttachmentUpdateRequestUi, UpdateAttachmentDto>();
        
        CreateMap<DefectDto, DefectResponseUi>();
        CreateMap<DefectRequestUi, CreateDefectDto>();
        CreateMap<DefectUpdateRequestUi, UpdateDefectDto>();
        
        CreateMap<DefectPhotoDto, DefectPhotoResponseUi>();
        CreateMap<DefectPhotoRequestUi, CreateDefectPhotoDto>();
        CreateMap<DefectUpdatePhotoRequestUi, UpdateDefectPhotoDto>();
        
        CreateMap<CommentDto, CommentResponseUi>();
        CreateMap<CommentRequestUi, CreateCommentDto>();
        CreateMap<CommentUpdateRequestUi, UpdateCommentDto>();
        
    }
}