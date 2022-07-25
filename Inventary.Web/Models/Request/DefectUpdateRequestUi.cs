namespace Inventary.Web.Models.Request;

public class DefectUpdateRequestUi
{
    public Guid? Id { get; set; }
    public string DefectName { get; set; }
    public string DefectDescription { get; set; }
    public List<DefectUpdatePhotoRequestUi>? DefectPhotos { get; set; }
    public Guid ItemId { get; set; }
}