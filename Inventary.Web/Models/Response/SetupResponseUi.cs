using Inventary.Domain.Enums;

namespace Inventary.Web.Models.Response;

public class SetupResponseUi
{
    public Guid Id { get; set; }
    public string SetupName { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public List<ItemForSetupsResponseUi>? Items { get; set; }
    public Guid UserId { get; set; }
}