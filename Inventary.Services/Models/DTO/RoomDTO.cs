using Inventary.Domain.Entities;

namespace Inventary.Services.Models.DTO;

public class RoomDto
{
    public Guid Id { get; set; }
    public string RoomName { get; set; }
}