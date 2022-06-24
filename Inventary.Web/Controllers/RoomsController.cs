using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Services.Contracts;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Inventary.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : Controller
{
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;
    
    public RoomsController(IServiceManager serviceManager, IMapper mapper)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
    }
    
    [HttpGet(nameof(GetAllRooms))]
    public async Task<IActionResult> GetAllRooms()
    {
        var rooms = await _serviceManager.RoomService.GetAllAsync();
        return Ok(rooms);
    }

    [HttpGet("[action]/{id:guid}")]
    public async Task<IActionResult> GetRoomById(Guid id)
    {
        try
        {
            var result = await _serviceManager.RoomService.GetByIdAsync(id);
            // var roomsDto = _mapper.Map<List<RoomDTO>>(rooms);
            var resultUI = _mapper.Map<RoomUIResponse>(result);
            return Ok(resultUI);
        }
        catch (Exception e)
        {
            return BadRequest("No records found");
        }
    }
    
    [HttpPost(nameof(CreateRoom))]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDTO room)
    {
        var newRoom = await _serviceManager.RoomService.CreateAsync(room);
        return CreatedAtAction(nameof(GetRoomById), new {id = newRoom.Id}, newRoom);
    }

    [HttpPut("UpdateRoom/{roomId:guid}")]
    public async Task<IActionResult> UpdateRoom(Guid roomId, [FromBody] CreateRoomDTO room)
    {
        await _serviceManager.RoomService.UpdateAsync(roomId, room);
        return NoContent();
    }

    [HttpDelete("DeleteRoom/{roomId:guid}")]
    public async Task<IActionResult> DeleteRoom(Guid roomId)
    {
        await _serviceManager.RoomService.DeleteAsync(roomId);
        return NoContent();
    }
    
}