namespace Inventary.Domain.Entities;

public class Comment : BaseEntity
{
    public string CommentDescription { get; set; }
    public Guid ItemId { get; set; }
}