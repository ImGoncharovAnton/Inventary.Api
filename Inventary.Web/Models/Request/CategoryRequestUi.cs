using System.ComponentModel.DataAnnotations;

namespace Inventary.Web.Models.Request;

public class CategoryRequestUi
{
    [Required]
    [MinLength(2), MaxLength(30)]
    public string CategoryName { get; set; }
}