using Inventary.Domain.Enums;

namespace Inventary.Repositories.Common.Models;

public class ListItemsForStorage
{
    public Guid Id { get; set; }
    public string ItemName { get; set; }
    public DateTime UserDate { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public double Price { get; set; }
    public string QRcode { get; set; }
    public string RoomName { get; set; }
    public string SetupName { get; set; }
    public int NumberOfDefects { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? SetupId { get; set; }
    public Guid? RoomId { get; set; }
}