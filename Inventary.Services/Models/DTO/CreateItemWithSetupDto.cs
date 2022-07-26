namespace Inventary.Services.Models.DTO;

public class CreateItemWithSetupDto
{
    public Guid Id { get; set; }
    public Guid? SetupId { get; set; }
}