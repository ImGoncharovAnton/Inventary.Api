namespace Inventary.Repositories.Common.Models;

public class ListItemsForStorageResponse
{
    public List<ListItemsForStorage> Items { get; set; } = new List<ListItemsForStorage>();
    public int Pages { get; set; }
    public int CurrentPage { get; set; }
}