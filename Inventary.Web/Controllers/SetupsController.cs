using AutoMapper;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Inventary.Web.Controllers;

[Route("api/[controller]/[action]")]
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
        var setups = await _serviceManager.SetupService.GetAllItems();
        var result = _mapper.Map<List<SetupResponseUi>>(setups);
        return Ok(result);
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

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteSetup(Guid id)
    {
        await _serviceManager.SetupService.DeleteAsync(id);
        return NoContent();
    }
}