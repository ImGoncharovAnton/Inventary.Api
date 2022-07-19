namespace Inventary.Services.Models.DTO;

public class AttachmentDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string FileName { get; set; }
    public int FileSize { get; set; }
    public string FileType { get; set; }
    public string FileUrl { get; set; }
    public Guid ItemId { get; set; }
}