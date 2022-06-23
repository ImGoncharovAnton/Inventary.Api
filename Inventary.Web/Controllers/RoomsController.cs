using Inventary.Domain.Entities;
using Inventary.Services.Contracts;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Inventary.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : Controller
{
    private readonly IServiceManager _serviceManager;
    
    public RoomsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    // [HttpGet]
    // public async Task<IActionResult> GetRooms(CancellationToken cancellationToken)
    // {
    //     var rooms = _serviceManager.RoomService.GetAllAsync(cancellationToken);
    //     return Ok(rooms);
    // }
    
    // private readonly IServiceRoom _serviceRoom;
    // public RoomsController(IServiceRoom serviceRoom)
    // {
    //     _serviceRoom = serviceRoom;
    // }

    [HttpGet(nameof(GetAllRooms))]
    public IActionResult GetAllRooms()
    {
        var rooms = _serviceManager.ServiceRoom.GetAll();
        return Ok(rooms);
        
        // return BadRequest("No record found");
    }
    
    
    [HttpGet(nameof(GetRoomById))]
    public async Task<IActionResult> GetRoomById(Guid id)
    {
        var result = await _serviceManager.ServiceRoom.GetByIdAsync(id);
        return Ok(result);

        // return BadRequest("No records found");
    }
    
    [HttpPost(nameof(CreateRoom))]
    public async Task<IActionResult> CreateRoom([FromBody] RoomDTO room)
    {
        var newRoom = await _serviceManager.ServiceRoom.CreateAsync(room);
        return CreatedAtAction(nameof(GetRoomById), new {id = newRoom.Id}, newRoom);
    }

    [HttpPut("{roomId:guid}")]
    public async Task<IActionResult> UpdateRoom(Guid roomId, [FromBody] RoomDTO room)
    {
        await _serviceManager.ServiceRoom.UpdateAsync(roomId, room);
        return NoContent();
    }

    [HttpDelete("{roomId:guid}")]
    public async Task<IActionResult> DeleteRoom(Guid roomId)
    {
        await _serviceManager.ServiceRoom.DeleteAsync(roomId);
        return Ok("Data deleted");
    }
    
}