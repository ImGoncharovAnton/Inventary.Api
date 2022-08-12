namespace Inventary.Web.Models.Request;

public class CommentUpdateRequestUi
{
    public Guid? Id { get; set; }
    public string CommentDescription { get; set; }
    public Guid ItemId { get; set; }
    public DateTime UserDate { get; set; }
    public bool IsEdit { get; set; }
}