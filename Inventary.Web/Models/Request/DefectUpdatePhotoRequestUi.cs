namespace Inventary.Web.Models.Request;

public class DefectUpdatePhotoRequestUi
{
    public Guid? Id { get; set; }
    public string OrigUrl { get; set; }
    public Guid DefectId { get; set; }
}