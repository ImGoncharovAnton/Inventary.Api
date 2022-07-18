namespace Inventary.Domain.Entities;

public class ItemPhoto: BaseEntity
{
    public string OrigUrl { get; set; }
    public Guid ItemId { get; set; }
    public virtual Item Item { get; set; }
}