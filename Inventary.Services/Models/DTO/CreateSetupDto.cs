using Inventary.Domain.Enums;

namespace Inventary.Services.Models.DTO;

public class CreateSetupDto
{
    public string SetupName { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public Guid? RoomId { get; set; }
    public List<CreateItemWithSetupDto>? Items { get; set; }
    public Guid? UserId { get; set; }
}