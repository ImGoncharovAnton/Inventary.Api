namespace Inventary.Services.Models.DTO;

public class CreateItemPhotoDto
{
    public string OrigUrl { get; set; }
    public Guid ItemId { get; set; }
}