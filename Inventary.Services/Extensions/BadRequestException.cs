namespace Inventary.Services.Extensions;

public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message) 
        : base(message)
    {
        
    }
}