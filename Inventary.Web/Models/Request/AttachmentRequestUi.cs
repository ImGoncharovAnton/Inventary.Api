namespace Inventary.Web.Models.Request;

public class AttachmentRequestUi
{
    public string FileName { get; set; }
    public int FileSize { get; set; }
    public string FileType { get; set; }
    public string FileUrl { get; set; }
    public Guid ItemId { get; set; }
}