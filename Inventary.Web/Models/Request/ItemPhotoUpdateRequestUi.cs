namespace Inventary.Web.Models.Request;

public class ItemPhotoUpdateRequestUi
{
    public Guid? Id { get; set; }
    public string OrigUrl { get; set; }
    public Guid ItemId { get; set; }
}