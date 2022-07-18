using Inventary.Services.Models.DTO;

namespace Inventary.Web.Models.Response;

public class RoomResponseUi
{
    public Guid Id { get; set; }
    public string RoomName { get; set; }
    public List<ItemDto>? Items { get; set; }
}