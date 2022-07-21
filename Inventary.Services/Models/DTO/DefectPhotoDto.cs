namespace Inventary.Services.Models.DTO;

public class DefectPhotoDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string OrigUrl { get; set; }
    public Guid DefectId { get; set; }
}