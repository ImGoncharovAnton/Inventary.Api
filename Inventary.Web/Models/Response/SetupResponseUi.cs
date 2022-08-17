using Inventary.Domain.Enums;

namespace Inventary.Web.Models.Response;

public class SetupResponseUi
{
    public Guid Id { get; set; }
    public string SetupName { get; set; }
    public string QrCode { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public Guid? RoomId { get; set; }
    public List<ItemForSetupsResponseUi>? Items { get; set; }
    public Guid? UserId { get; set; }
    public string UserFullName { get; set; }
}