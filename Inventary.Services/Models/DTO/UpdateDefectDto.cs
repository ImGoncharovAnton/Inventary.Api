namespace Inventary.Services.Models.DTO;

public class UpdateDefectDto
{
    public Guid? Id { get; set; }
    public string DefectName { get; set; }
    public string DefectDescription { get; set; }
    public List<UpdateDefectPhotoDto>? DefectPhotos { get; set; }
    public Guid ItemId { get; set; }
}