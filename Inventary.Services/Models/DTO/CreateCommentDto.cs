namespace Inventary.Services.Models.DTO;

public class CreateCommentDto
{
    public string CommentDescription { get; set; }
    public Guid ItemId { get; set; }
}