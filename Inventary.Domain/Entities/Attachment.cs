namespace Inventary.Domain.Entities;

public class Attachment: BaseEntity
{
    public string AttachmentName { get; set; }
    public string OrigUrl { get; set; }
    public Guid ItemId { get; set; }
}