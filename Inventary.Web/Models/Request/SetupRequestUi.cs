using System.ComponentModel.DataAnnotations;
using Inventary.Domain.Enums;

namespace Inventary.Web.Models.Request;

public class SetupRequestUi
{
    [Required]
    [MinLength(3), MaxLength(30)]
    public string SetupName { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public Guid? RoomId { get; set; }
    public List<ItemForSetupsRequestUi>? Items { get; set; }
    public Guid? UserId { get; set; }
}