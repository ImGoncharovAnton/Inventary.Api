using Inventary.Domain.Enums;

namespace Inventary.Repositories.Common.Models;

public class SetupsListForSelect
{
    public Guid Id { get; set; }
    public string SetupName { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public List<ListItemsForSetupSelect>? Items { get; set; }
    public Guid? UserId { get; set; }
}