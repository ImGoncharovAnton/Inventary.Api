using Inventary.Domain.Enums;

namespace Inventary.Domain.Entities;

public class Item: BaseEntity
{
    public string ItemName { get; set; }
    public Status.StatusType Status { get; set; }
    public decimal Price { get; set; }
    public int Number { get; set; }
    public virtual List<Setup> Setups { get; set; }
}