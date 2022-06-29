namespace Inventary.Services.Extensions;

public sealed class RoomNotFoundException : NotFoundException
{
    public RoomNotFoundException(Guid roomId)
    :base ($"The room with the identifier {roomId} was not found.")
    {
        
    }
}