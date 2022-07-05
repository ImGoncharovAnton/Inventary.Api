namespace Inventary.Domain.Entities;

public class Category: BaseEntity
{
    public string CategoryName { get; set; }
    public List<Item?> Items { get; set; }
}