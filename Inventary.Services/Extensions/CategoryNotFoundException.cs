namespace Inventary.Services.Extensions;

public class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException(Guid categoryId) :
        base($"The user with the identifier {categoryId} was not found.")
    {
    }
}