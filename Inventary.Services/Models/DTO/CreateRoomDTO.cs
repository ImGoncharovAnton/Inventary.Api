using System.ComponentModel.DataAnnotations;
using Inventary.Domain.Entities;

namespace Inventary.Services.Models.DTO;

public class CreateRoomDTO
{
    [Required]
    [MinLength(2), MaxLength(30)]
    public string RoomName { get; set; }
}