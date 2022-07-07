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
    public Guid? UserId { get; set; }
    public Guid? CategoryId { get; set; }
    public virtual Category Category { get; set; }
    
   
    // public virtual List<Setup?> Setups { get; set; }
 
}