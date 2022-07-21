using Inventary.Domain.Entities;
using Inventary.Domain.Enums;
using Inventary.Services.Models.DTO;

namespace Inventary.Web.Models.Request;

public class ItemRequestUi
{
    public string ItemName { get; set; }
    public DateTime UserDate { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public double Price { get; set; }
    public string QRcode { get; set; }
    public Guid? RoomId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CurrentCategoryId { get; set; }
    public List<ItemPhotoRequestUi>? ItemPhotos { get; set; }
    public List<AttachmentRequestUi>? Attachments { get; set; }
    public List<DefectRequestUi>? Defects { get; set; }
    public List<CommentRequestUi>? Comments { get; set; }
}