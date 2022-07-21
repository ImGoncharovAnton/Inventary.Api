namespace Inventary.Services.Models.DTO;

public class DefectDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string DefectName { get; set; }
    public string DefectDescription { get; set; }
    public List<DefectPhotoDto>? DefectPhotos { get; set; }
    public Guid ItemId { get; set; }
}