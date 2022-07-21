namespace Inventary.Services.Models.DTO;

public class CommentDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CommentDescription { get; set; }
    public Guid ItemId { get; set; }
}