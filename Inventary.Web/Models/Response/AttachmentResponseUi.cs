namespace Inventary.Web.Models.Response;

public class AttachmentResponseUi
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public int FileSize { get; set; }
    public string FileType { get; set; }
    public string FileUrl { get; set; }
    public Guid ItemId { get; set; }
}