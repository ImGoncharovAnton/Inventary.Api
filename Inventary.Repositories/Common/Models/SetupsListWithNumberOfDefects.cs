using Inventary.Domain.Entities;
using Inventary.Domain.Enums;

namespace Inventary.Repositories.Common.Models;

public class SetupsListWithNumberOfDefects
{
    public Guid Id { get; set; }
    public string SetupName { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public Guid? RoomId { get; set; }
    public Guid? UserId { get; set; }
    public int NumberOfDefects { get; set; }
    public string FullName { get; set; }

    public List<ListItemsForUpdate> Items { get; set; }
}