namespace Inventary.Web.Models.Response;

public class DefectResponseUi
{
    public Guid Id { get; set; }
    public string DefectName { get; set; }
    public string DefectDescription { get; set; }
    public List<DefectPhotoResponseUi>? DefectPhotos { get; set; }
    public Guid ItemId { get; set; }
}