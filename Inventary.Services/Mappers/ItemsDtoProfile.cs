using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Mappers;

public class ItemsDtoProfile : Profile
{
    public ItemsDtoProfile()
    {
        CreateMap<Item, ItemDto>().ReverseMap();
        CreateMap<CreateItemDto, Item>();
        CreateMap<ItemPhoto, ItemPhotoDto>().ReverseMap();
        CreateMap<CreateItemPhotoDto, ItemPhoto>();
        CreateMap<Attachment, AttachmentDto>().ReverseMap();
        CreateMap<CreateAttachementDto, Attachment>();
        CreateMap<Defect, DefectDto>().ReverseMap();
        CreateMap<CreateDefectDto, Defect>();
        CreateMap<DefectPhoto, DefectPhotoDto>().ReverseMap();;
        CreateMap<CreateDefectPhotoDto, DefectPhoto>();
        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<CreateCommentDto, Comment>();
    }
}