using Inventary.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inventary.Services.Models.DTO;

public class UpdateSetupDto
{
    public Guid Id { get; set; }
    public string SetupName { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public Guid? RoomId { get; set; }
    public List<CreateItemWithSetupDto>? Items { get; set; }
    public Guid? UserId { get; set; }
}