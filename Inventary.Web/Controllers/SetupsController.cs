﻿using AutoMapper;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventary.Web.Controllers;

[Route("api/[controller]/[action]")]
[Authorize(Roles = "Admin, Manager")]
public class SetupsController : Controller
{
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;

    public SetupsController(IServiceManager serviceManager, IMapper mapper)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllSetups()
    {
        var setups = await _serviceManager.SetupService.GetAllWithNumberOfDefects();
        return Ok(setups);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetListSetupsWithoutUser()
    {
        var setups = await _serviceManager.SetupService.GetAllSetupsWithoutUser();
        return Ok(setups);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllSetupsForSelect()
    {
        var setups = await _serviceManager.SetupService.GetAllSetupsForSelect();
        return Ok(setups);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAllSetupsForRoom(Guid id)
    {
        var setups = await _serviceManager.SetupService.GetAllSetupsForRoomById(id);
        return Ok(setups);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetSetupById(Guid id)
    {
        var setup = await _serviceManager.SetupService.GetByIdAsync(id);
        var result = _mapper.Map<SetupResponseUi>(setup);
        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateSetup([FromBody] SetupRequestUi setupRequest)
    {
        var mappedSetup = _mapper.Map<CreateSetupDto>(setupRequest);
        var newSetup = await _serviceManager.SetupService.CreateAsync(mappedSetup);
        var result = _mapper.Map<SetupResponseUi>(newSetup);

        return CreatedAtAction(nameof(GetSetupById), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateSetup(Guid id, [FromBody] SetupUpdateRequestUi setupUpdateRequest)
    {
        var mappedSetup = _mapper.Map<UpdateSetupDto>(setupUpdateRequest);
        await _serviceManager.SetupService.UpdateAsync(id, mappedSetup);
        return NoContent();
    }
    [HttpPut("{roomId:guid}")]
    public async Task<IActionResult> MoveSetupsToAnotherRoom(Guid roomId, [FromBody] List<ListMoveSetupsDto> items)
    {
        await _serviceManager.SetupService.MoveSetupsToAnotherRoom(roomId, items);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> ToggleSetupStatus(Guid id, [FromBody] SetupForUpdateStatusDto setup)
    {
        await _serviceManager.SetupService.ToggleSetupStatus(id, setup);
        return NoContent();
    }
    
    [HttpPut("")]
    public async Task<IActionResult> ToggleSetupStatusList([FromBody] List<SetupForUpdateStatusDto> setups)
    {
        await _serviceManager.SetupService.ToggleSetupStatusList(setups);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteSetup(Guid id)
    {
        await _serviceManager.SetupService.DeleteAsync(id);
        return NoContent();
    }
}