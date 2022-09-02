using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Mappers;

public class ItemsDtoProfile : Profile
{
    public ItemsDtoProfile()
    {
        
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[6];
        var random = new Random();

        for (var i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var finalString = new String(stringChars);
        
        CreateMap<Item, ItemDto>().ReverseMap();
        CreateMap<CreateItemDto, Item>()
            .ForMember(dest => dest.QRcode, opt =>
                opt.MapFrom(src => finalString))
            .ForMember(dest => dest.UserDate, opt => 
                opt.MapFrom((src => src.UserDate ?? DateTime.UtcNow)));
        CreateMap<UpdateItemDto, Item>();
        CreateMap<ItemsForRoom, Item>();
        
        CreateMap<ItemPhoto, ItemPhotoDto>().ReverseMap();
        CreateMap<CreateItemPhotoDto, ItemPhoto>();
        CreateMap<UpdateItemPhotoDto, ItemPhoto>();
        
        CreateMap<Attachment, AttachmentDto>().ReverseMap();
        CreateMap<CreateAttachementDto, Attachment>();
        CreateMap<UpdateAttachmentDto, Attachment>();
        
        CreateMap<Defect, DefectDto>().ReverseMap();
        CreateMap<CreateDefectDto, Defect>();
        CreateMap<UpdateDefectDto, Defect>();
        
        CreateMap<DefectPhoto, DefectPhotoDto>().ReverseMap();;
        CreateMap<CreateDefectPhotoDto, DefectPhoto>();
        CreateMap<UpdateDefectPhotoDto, DefectPhoto>();
        
        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<CreateCommentDto, Comment>();
        CreateMap<UpdateCommentDto, Comment>();
        
    }
}