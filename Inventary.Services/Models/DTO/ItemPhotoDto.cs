using Inventary.Domain.Entities;

namespace Inventary.Services.Models.DTO;

public class ItemPhotoDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string OrigUrl { get; set; }
    public Guid ItemId { get; set; }
}