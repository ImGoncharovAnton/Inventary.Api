using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Services.Contracts;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Inventary.Web.Controllers;

[Route("api/[controller]/[action]")]
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

    [HttpGet("")]
    public async Task<IActionResult> GetAllRooms()
    {
        var rooms = await _serviceManager.RoomService.GetAllAsync();
        return Ok(rooms);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllWithItems()
    {
        var rooms = await _serviceManager.RoomService.GetAllAsyncWithItems();
        return Ok(rooms);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRoomById(Guid id)
    {
        var result = await _serviceManager.RoomService.GetByIdAsync(id);
        var resultUi = _mapper.Map<RoomResponseUi>(result);
        return Ok(resultUi);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRoomByIdWithItems(Guid id)
    {
        var result = await _serviceManager.RoomService.GetByIdWithItems(id);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRoomByIdWithCategories(Guid id)
    {
        var result = await _serviceManager.RoomService.GetByIdWithCategory(id);
        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDTO room)
    {
        var newRoom = await _serviceManager.RoomService.CreateAsync(room);
        return CreatedAtAction(nameof(GetRoomById), new { id = newRoom.Id }, newRoom);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateListRooms([FromBody] List<CreateRoomDTO> rooms)
    {
        await _serviceManager.RoomService.CreateRangeAsync(rooms);
        return NoContent();
    }

    [HttpPut("{roomId:guid}")]
    public async Task<IActionResult> UpdateRoom(Guid roomId, [FromBody] CreateRoomDTO room)
    {
        await _serviceManager.RoomService.UpdateAsync(roomId, room);
        return NoContent();
    }

    [HttpDelete("{roomId:guid}")]
    public async Task<IActionResult> DeleteRoom(Guid roomId)
    {
        await _serviceManager.RoomService.DeleteAsync(roomId);
        return NoContent();
    }
}