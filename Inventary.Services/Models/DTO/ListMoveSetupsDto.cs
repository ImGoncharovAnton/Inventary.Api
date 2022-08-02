using Inventary.Repositories.Common.Models;

namespace Inventary.Services.Models.DTO;

public class ListMoveSetupsDto
{
    public Guid Id { get; set; }
    public string SetupName { get; set; }
    public List<ListItemsForUpdate> Items { get; set; }
}