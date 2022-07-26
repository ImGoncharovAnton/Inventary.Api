using Inventary.Domain.Enums;

namespace Inventary.Domain.Entities;

public class Item: BaseEntity
{
    public string ItemName { get; set; }
    public DateTime UserDate { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public double Price { get; set; }
    public string QRcode { get; set; }
    public Guid? RoomId { get; set; }
    // public virtual Room Room { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CurrentCategoryId { get; set; }
    public Guid? SetupId { get; set; }
    public virtual Category? Category { get; set; }
    public virtual List<Comment>? Comments { get; set; }
    public virtual List<Defect>? Defects { get; set; }
    public virtual List<Attachment>? Attachments { get; set; }
    public virtual List<ItemPhoto>? ItemPhotos { get; set; }


    // public virtual List<Setup>? Setups { get; set; }
 
}