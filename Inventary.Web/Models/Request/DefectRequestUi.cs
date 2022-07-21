namespace Inventary.Web.Models.Request;

public class DefectRequestUi
{
    public string DefectName { get; set; }
    public string DefectDescription { get; set; }
    public List<DefectPhotoRequestUi>? DefectPhotos { get; set; }
    public Guid ItemId { get; set; }
}