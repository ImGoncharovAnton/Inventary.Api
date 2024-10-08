﻿using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventary.Web.Controllers;

[Route("api/[Controller]/[action]")]
[ApiController]
[Authorize(Roles = "Admin, Manager")]
public class ItemsController : Controller
{
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;

    public ItemsController(IServiceManager serviceManager, IMapper mapper)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllItems()
    {
        var items = await _serviceManager.ItemService.GetAllItems();
        return Ok(items);
    }
    
    [HttpPost("")]
    public async Task<IActionResult> ListItemsWithFilters([FromBody] RequestParams parameters)
    {
        var items = await _serviceManager.ItemService.GetItemsByPage(parameters);

       return Ok(items);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetItemById(Guid id)
    {
        var item = await _serviceManager.ItemService.GetByIdAsync(id);
        var result = _mapper.Map<ItemResponseUi>(item);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetItemsListBySetupId(Guid id)
    {
        var items = await _serviceManager.ItemService.GetItemsListBySetupId(id);
        return Ok(items);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetListItemsWithoutSetups()
    {
        var items = await _serviceManager.ItemService.GetItemsListAsync();
        return Ok(items);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateItem([FromBody] ItemRequestUi itemRequest)
    {
        var mappedItem = _mapper.Map<CreateItemDto>(itemRequest);
        var newItem = await _serviceManager.ItemService.CreateAsync(mappedItem);
        var result = _mapper.Map<ItemResponseUi>(newItem);

        return CreatedAtAction(nameof(GetItemById), new { id = result.Id }, result);
    }

    [HttpPut("{itemId:guid}")]
    public async Task<IActionResult> UpdateItem(Guid itemId, [FromBody] ItemUpdateRequestUi itemRequest)
    {
        var mappedItem = _mapper.Map<UpdateItemDto>(itemRequest);
        await _serviceManager.ItemService.UpdateAsync(itemId, mappedItem);
        var item = await _serviceManager.ItemService.GetByIdAsync(itemId);
        var result = _mapper.Map<ItemResponseUi>(item);
        return Ok(result);
    }

    [HttpPut("{roomId:guid}")]
    public async Task<IActionResult> MoveItemsToAnotherRoom(Guid roomId, [FromBody] List<ListItemsForUpdate> items)
    {
        await _serviceManager.ItemService.MoveItemsToAnotherRoom(roomId, items);
        return NoContent();
    }

    [HttpDelete("{itemId:guid}")]
    public async Task<IActionResult> DeleteItem(Guid itemId)
    {
        return Ok (await _serviceManager.ItemService.DeleteAsync(itemId));
    }


    [HttpDelete("")]
    public async Task<IActionResult> DeleteListItems([FromBody] List<ItemsForRoom> items)
    {
        var result = await _serviceManager.ItemService.DeleteRange(items);
        return Ok(result);
    }
}