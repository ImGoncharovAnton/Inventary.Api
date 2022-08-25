namespace Inventary.Repositories.Common.Models;

public class ListItemsForStorageResponse
{
    public List<ListItemsForStorage> Items { get; set; } = new List<ListItemsForStorage>();
    public int TotalCount { get; set; }
    public int PageSize { get; set;}
    public int PageIndex { get; set;}
    public int TotalPages { get; set;}
    public bool HasNextPage { get; set;}
    public bool HasPreviousPage { get; set;}
}