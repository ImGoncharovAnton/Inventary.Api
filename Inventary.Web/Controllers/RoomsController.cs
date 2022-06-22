using Inventary.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Inventary.Web.Controllers;

[ApiController]
[Route("api/rooms")]
public class RoomsController : Controller
{
    private readonly IServiceManager _serviceManager;

    public RoomsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetRooms()
    {
        var rooms = _serviceManager.RoomService.GetAllAsync();
        return Ok(rooms);
    }
}