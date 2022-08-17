using Inventary.Domain.Enums;

namespace Inventary.Repositories.Common.Models;

public class ItemsList
{
    public Guid Id { get; set; }
    public string QrCode { get; set; }
    public string ItemName { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public string? RoomName { get; set; }
    public int NumberOfDefects { get; set; }
    public Guid? RoomId { get; set; }
    public Guid? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public Guid? SetupId { get; set; }
    public Guid? UserId { get; set; }

}