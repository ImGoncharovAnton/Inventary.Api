using System.ComponentModel.DataAnnotations;
using Inventary.Domain.Enums;

namespace Inventary.Web.Models.Request;

public class ItemUpdateRequestUi
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    [MinLength(3), MaxLength(30)]
    public string ItemName { get; set; }
    public DateTime UserDate { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    [Range(0.0, Double.MaxValue)]
    public double Price { get; set; }
    public string QRcode { get; set; }
    public Guid? RoomId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CurrentCategoryId { get; set; }
    public Guid? SetupId { get; set; }
    public List<ItemPhotoUpdateRequestUi>? ItemPhotos { get; set; }
    public List<AttachmentUpdateRequestUi>? Attachments { get; set; }
    public List<DefectUpdateRequestUi>? Defects { get; set; }
    public List<CommentUpdateRequestUi>? Comments { get; set; }
}