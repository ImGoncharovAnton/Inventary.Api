using Inventary.Domain.Entities;
using Inventary.Domain.Enums;

namespace Inventary.Services.Models.DTO;

public class ItemDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string ItemName { get; set; }
    public DateTime UserDate { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public double Price { get; set; }
    public string QRcode { get; set; }
    public Guid? RoomId { get; set; }
    public virtual Room? Room { get; set; }
    public Guid? UserId { get; set; }
    public virtual User? User { get; set; }
    public Guid? CurrentCategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public Guid? SetupId { get; set; }
    public virtual Setup? Setup { get; set; }
    public List<ItemPhotoDto>? ItemPhotos { get; set; }
    public List<AttachmentDto>? Attachments { get; set; }
    public List<DefectDto>? Defects { get; set; }
    public List<CommentDto>? Comments { get; set; }
}