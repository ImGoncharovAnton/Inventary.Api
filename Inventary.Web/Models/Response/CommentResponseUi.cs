namespace Inventary.Web.Models.Response;

public class CommentResponseUi
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CommentDescription { get; set; }
    public Guid ItemId { get; set; }
    public DateTime UserDate { get; set; }
    public bool IsEdit { get; set; }
}