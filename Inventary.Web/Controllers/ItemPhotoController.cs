using AutoMapper;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Inventary.Web.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ItemPhotoController : Controller
{
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;

    public ItemPhotoController(IServiceManager serviceManager, IMapper mapper)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllItemsPhoto()
    {
        var items = await _serviceManager.ItemPhotoService.GetAllAsync();
        var result = _mapper.Map<List<ItemPhotoResponseUi>>(items);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetItemPhotoById(Guid id)
    {
        var item = await _serviceManager.ItemPhotoService.GetByIdAsync(id);
        var result = _mapper.Map<ItemPhotoResponseUi>(item);
        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateItemPhoto([FromBody] ItemPhotoRequestUi itemPhoto)
    {
        var mappedItemPhoto = _mapper.Map<CreateItemPhotoDto>(itemPhoto);
        var newItem = await _serviceManager.ItemPhotoService.CreateAsync(mappedItemPhoto);
        var result = _mapper.Map<ItemPhotoResponseUi>(newItem);

        return CreatedAtAction(nameof(GetItemPhotoById), new { id = result.Id }, result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteItemPhoto(Guid id)
    {
        await _serviceManager.ItemPhotoService.DeleteAsync(id);
        return NoContent();
    }
    
    
}