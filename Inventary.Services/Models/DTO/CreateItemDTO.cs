using Inventary.Domain.Entities;
using Inventary.Domain.Enums;

namespace Inventary.Services.Models.DTO;

public class CreateItemDto
{
    public string ItemName { get; set; }
    public DateTime UserDate { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public double Price { get; set; }
    public int Number { get; set; }
    public string QRcode { get; set; }
    public Guid? RoomId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CategoryId { get; set; }
}