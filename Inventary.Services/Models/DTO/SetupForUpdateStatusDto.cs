using Inventary.Domain.Enums;

namespace Inventary.Services.Models.DTO;

public class SetupForUpdateStatusDto
{
    public Guid Id { get; set; }
    public string SetupName { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public List<ListItemsForUpdateStatusDto>? Items { get; set; }
}