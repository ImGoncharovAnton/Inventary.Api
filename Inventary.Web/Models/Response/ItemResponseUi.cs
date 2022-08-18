using Inventary.Domain.Entities;
using Inventary.Domain.Enums;

namespace Inventary.Web.Models.Response;

public class ItemResponseUi
{
    public Guid Id { get; set; }
    public string ItemName { get; set; }
    public DateTime UserDate { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public double Price { get; set; }
    public string QRcode { get; set; }
    public Guid? RoomId { get; set; }
    public string RoomName { get; set; }
    public Guid? UserId { get; set; }
    public string UserName { get; set; }
    public Guid? CurrentCategoryId { get; set; }
    public string CategoryName { get; set; }
    public Guid? SetupId { get; set; }
    public string SetupName { get; set; }
    public List<ItemPhotoResponseUi>? ItemPhotos { get; set; }
    public List<AttachmentResponseUi>? Attachments { get; set; }
    public List<DefectResponseUi>? Defects { get; set; }
    public List<CommentResponseUi>? Comments { get; set; }
}