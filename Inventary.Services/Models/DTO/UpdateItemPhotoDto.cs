namespace Inventary.Services.Models.DTO;

public class UpdateItemPhotoDto
{
    public Guid? Id { get; set; }
    public string OrigUrl { get; set; }
    public Guid ItemId { get; set; }
}