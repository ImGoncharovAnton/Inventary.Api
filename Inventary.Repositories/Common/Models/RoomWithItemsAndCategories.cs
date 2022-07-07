using Inventary.Domain.Entities;

namespace Inventary.Repositories.Common.Models;

public class RoomWithItemsAndCategories
{
    public Guid Id { get; set; }
    public string RoomName { get; set; }
    public List<Item> Items { get; set; }
    public List<Category> Categories { get; set; }
}