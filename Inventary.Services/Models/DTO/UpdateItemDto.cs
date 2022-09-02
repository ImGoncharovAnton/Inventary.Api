using System.ComponentModel.DataAnnotations;
using Inventary.Domain.Enums;

namespace Inventary.Services.Models.DTO;

public class UpdateItemDto
{
    public Guid Id { get; set; }
    [MaxLength(50)]
    public string ItemName { get; set; }
    public DateTime? UserDate { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public double Price { get; set; }
    public string QRcode { get; set; }
    public Guid? RoomId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CurrentCategoryId { get; set; }
    public Guid? SetupId { get; set; }
    public List<UpdateItemPhotoDto>? ItemPhotos { get; set; }
    public List<UpdateAttachmentDto>? Attachments { get; set; }
    public List<UpdateDefectDto>? Defects { get; set; }
    public List<UpdateCommentDto>? Comments { get; set; }
}