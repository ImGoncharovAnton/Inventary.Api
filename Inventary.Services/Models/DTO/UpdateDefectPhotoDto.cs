namespace Inventary.Services.Models.DTO;

public class UpdateDefectPhotoDto
{
    public Guid? Id { get; set; }
    public string OrigUrl { get; set; }
    public Guid DefectId { get; set; }
}