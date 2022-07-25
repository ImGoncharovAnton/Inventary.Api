using AutoMapper;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;

namespace Inventary.Web.Mappers;

public class ItemsUiProfile: Profile
{
    public ItemsUiProfile()
    {
        CreateMap<ItemDto, ItemResponseUi>();
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