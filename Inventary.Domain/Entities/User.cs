using Inventary.Domain.Enums;

namespace Inventary.Domain.Entities;

public class User: BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    // public virtual List<Item>? Items { get; set; }
    // public Guid SetupId { get; set; }
    // public Setup Setup { get; set; }
}