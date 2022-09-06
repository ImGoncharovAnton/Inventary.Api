using System.ComponentModel.DataAnnotations;
using Inventary.Domain.Entities;
using Inventary.Domain.Enums;
using Inventary.Services.Models.DTO;

namespace Inventary.Web.Models.Request;

public class UserRequestUi
{
    [Required]
    [MinLength(2), MaxLength(25)]
    public string FirstName { get; set; }
    [Required]
    [MinLength(2), MaxLength(25)]
    public string LastName { get; set; }
    [Required]
    [MinLength(17), MaxLength(17)]
    public string Phone { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public StatusEnum.StatusType Status { get; set; }
    public List<Item>? Items { get; set; }
    public string urlOrig { get; set; }
    public string urlCrop { get; set; }
    public Guid? CurrentSetupId { get; set; }
    
}