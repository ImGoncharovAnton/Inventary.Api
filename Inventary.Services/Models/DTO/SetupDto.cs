using Inventary.Domain.Enums;

namespace Inventary.Services.Models.DTO;

public class SetupDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string SetupName { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public List<ItemDto>? Items { get; set; }
    public Guid UserId { get; set; }
}