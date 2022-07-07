using Inventary.Domain.Entities;

namespace Inventary.Services.Models.DTO;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; }
    public List<Item?> Items { get; set; }
}