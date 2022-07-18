namespace Inventary.Domain.Entities;

public class Defect: BaseEntity
{
    public string DefectName { get; set; }
    public string DefectDescription { get; set; }
    public List<DefectPhoto>? DefectPhotos { get; set; }
    public Guid ItemId { get; set; }
}