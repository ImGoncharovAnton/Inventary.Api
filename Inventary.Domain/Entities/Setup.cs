using Inventary.Domain.Enums;

namespace Inventary.Domain.Entities;

public class Setup: BaseEntity
{
    public string SetupName { get; set; }
    public Status.StatusType Status { get; set; }
    public virtual List<Item> Items { get; set; }
    // public User User { get; set; }
}