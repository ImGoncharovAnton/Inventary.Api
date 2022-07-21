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
        CreateMap<ItemPhotoDto, ItemPhotoResponseUi>();
        CreateMap<ItemPhotoRequestUi, CreateItemPhotoDto>();
        CreateMap<AttachmentDto, AttachmentResponseUi>();
        CreateMap<AttachmentRequestUi, CreateAttachementDto>();
        CreateMap<DefectDto, DefectResponseUi>();
        CreateMap<DefectRequestUi, CreateDefectDto>();
        CreateMap<DefectPhotoDto, DefectPhotoResponseUi>();
        CreateMap<DefectPhotoRequestUi, CreateDefectPhotoDto>();
        CreateMap<CommentDto, CommentResponseUi>();
        CreateMap<CommentRequestUi, CreateCommentDto>();
    }
}