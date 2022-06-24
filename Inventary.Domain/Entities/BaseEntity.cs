namespace Inventary.Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
}