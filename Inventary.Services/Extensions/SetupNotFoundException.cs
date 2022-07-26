namespace Inventary.Services.Extensions;

public class SetupNotFoundException : NotFoundException
{
    public SetupNotFoundException(Guid setupId) :
        base($"The setup with the identifier {setupId} was not found.")
    {
    }
}