using Inventary.Domain.Enums;

namespace Inventary.Web.Models.Request;

public class SetupRequestUi
{
    public string SetupName { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public List<ItemForSetupsRequestUi>? Items { get; set; }
    public Guid UserId { get; set; }
}