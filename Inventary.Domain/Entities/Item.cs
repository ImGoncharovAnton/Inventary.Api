using Inventary.Domain.Enums;

namespace Inventary.Domain.Entities;

public class Item
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    public string ItemName { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public decimal Price { get; set; }
    public int Number { get; set; }
    public virtual List<Setup> Setups { get; set; }
}