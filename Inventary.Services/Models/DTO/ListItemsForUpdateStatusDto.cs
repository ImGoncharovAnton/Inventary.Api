using Inventary.Domain.Enums;

namespace Inventary.Services.Models.DTO;

public class ListItemsForUpdateStatusDto
{
    public Guid Id { get; set; }
    public string ItemName { get; set; }
    public StatusEnum.StatusType Status { get; set; }
}