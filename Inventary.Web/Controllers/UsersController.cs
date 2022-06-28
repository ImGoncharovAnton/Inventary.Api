﻿using AutoMapper;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Inventary.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : Controller
{
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;

    public UsersController(IServiceManager serviceManager, IMapper mapper)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
    }

    [HttpGet(nameof(GetAllUsers))]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _serviceManager.UserService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("[action]/{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _serviceManager.UserService.GetByIdAsync(id);
        var result = _mapper.Map<UserResponseUi>(user);
        return Ok(result);
    }

    [HttpPost(nameof(CreateUser))]
    public async Task<IActionResult> CreateUser([FromBody] UserRequestUi userRequest)
    {
        var mappedUser = _mapper.Map<UserCreateDto>(userRequest);
        var newUser = await _serviceManager.UserService.CreateAsync(mappedUser);
        var result = _mapper.Map<UserResponseUi>(newUser);

        return CreatedAtAction(nameof(GetUserById), new { id = result.Id }, result);
    }

    [HttpPut("[action]/{userId:guid}")]
    public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UserRequestUi userRequest)
    {
        var mappedUser = _mapper.Map<UserCreateDto>(userRequest);
        await _serviceManager.UserService.UpdateAsync(userId, mappedUser);
        return NoContent();
    }

    [HttpDelete("action/{userId:guid}")]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        await _serviceManager.UserService.DeleteAsync(userId);
        return NoContent();
    }
}