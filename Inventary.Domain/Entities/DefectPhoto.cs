namespace Inventary.Domain.Entities;

public class DefectPhoto: BaseEntity
{
    public string OrigUrl { get; set; }
    public Guid DefectId { get; set; }
}