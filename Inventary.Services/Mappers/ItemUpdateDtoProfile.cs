// using AutoMapper;
// using Inventary.Domain.Entities;
// using Inventary.Services.Models.DTO;
//
// namespace Inventary.Services.Mappers;
//
// public class ItemUpdateDtoProfile : Profile
// {
//     public ItemUpdateDtoProfile()
//     {
//         CreateMap<Item, ItemDto>().ReverseMap();
//         CreateMap<UpdateItemDto, Item>();
//         CreateMap<ItemPhoto, ItemPhotoDto>().ReverseMap();
//         CreateMap<UpdateItemPhotoDto, ItemPhoto>();
//         CreateMap<Attachment, AttachmentDto>().ReverseMap();
//         CreateMap<UpdateAttachmentDto, Attachment>();
//         CreateMap<Defect, DefectDto>().ReverseMap();
//         CreateMap<UpdateDefectDto, Defect>();
//         CreateMap<DefectPhoto, DefectPhotoDto>().ReverseMap();;
//         CreateMap<UpdateDefectPhotoDto, DefectPhoto>();
//         CreateMap<Comment, CommentDto>().ReverseMap();
//         CreateMap<UpdateCommentDto, Comment>();
//     }
// }