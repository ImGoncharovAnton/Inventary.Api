using Inventary.Domain.Entities;
using Inventary.Domain.Enums;

namespace Inventary.Repositories.Common.Models;

public class ItemsForRoom
{
    public Guid Id { get; set; }
    public string ItemName { get; set; }
    public DateTime UserDate { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public double Price { get; set; }
    public string QRcode { get; set; }
    public string RoomName { get; set; }
    public Guid? CurrentCategoryId { get; set; }
    public List<Defect> Defects { get; set; }
    // public string CategoryName { get; set; }

}