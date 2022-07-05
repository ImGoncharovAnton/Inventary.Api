namespace Inventary.Services.Extensions;

public class ItemNotFoundException: NotFoundException
{
    public ItemNotFoundException(Guid itemId): 
        base($"The item with the identifier {itemId} was not found.")
    {
        
    }
}