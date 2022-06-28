using Inventary.Domain.Entities;
using Inventary.Domain.Enums;

namespace Inventary.Services.Models.DTO;

public class UserCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public Status.StatusType Status { get; set; }
    public List<Item>? Items { get; set; }
    // public Guid SetupId { get; set; }
    
}