using Inventary.Domain.Enums;

namespace Inventary.Domain.Entities;

public class Setup: BaseEntity
{
    public string SetupName { get; set; }
    public string QrCode { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public Guid? RoomId { get; set; }
    public virtual List<Item>? Items { get; set; }
    public Guid? UserId { get; set; }
    public virtual User? User { get; set; }
}