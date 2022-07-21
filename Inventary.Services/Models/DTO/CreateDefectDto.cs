namespace Inventary.Services.Models.DTO;

public class CreateDefectDto
{
    public string DefectName { get; set; }
    public string DefectDescription { get; set; }
    public List<CreateDefectPhotoDto>? DefectPhotos { get; set; }
    public Guid ItemId { get; set; }
}