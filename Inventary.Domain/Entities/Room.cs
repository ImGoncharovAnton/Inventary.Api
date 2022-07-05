namespace Inventary.Domain.Entities;

public class Room: BaseEntity
{
    public string RoomName { get; set; }
    public virtual List<Item?> Items { get; set; }
    // public virtual List<Setup?> Setups { get; set; }
    
}