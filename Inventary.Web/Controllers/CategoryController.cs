﻿using AutoMapper;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Inventary.Web.Models.Request;
using Inventary.Web.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventary.Web.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(Roles = "Admin, Manager")]
public class CategoryController : Controller
{
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;

    public CategoryController(IServiceManager serviceManager, IMapper mapper)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetAllWithItems()
    {
        var categories = await _serviceManager.CategoryService.GetAllWithItemsAsync();
        return Ok(categories);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var category = await _serviceManager.CategoryService.GetByIdAsync(id);
        var result = _mapper.Map<CategoryResponseUi>(category);
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAllCategoriesBySetupId(Guid id)
    {
        var result = await _serviceManager.CategoryService.GetAllCategoriesBySetupId(id);
        return Ok(result);
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateListCategory([FromBody] List<CategoryRequestUi> categoryRequestList)
    {
        var mappedCategory = _mapper.Map<List<CreateCategoryDto>>(categoryRequestList);
        var result = await _serviceManager.CategoryService.CreateRangeAsync(mappedCategory);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryRequestUi categoryRequest)
    {
        var mappedCategory = _mapper.Map<CreateCategoryDto>(categoryRequest);
        await _serviceManager.CategoryService.UpdateAsync(id, mappedCategory);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var result = await _serviceManager.CategoryService.DeleteAsync(id);
        return Ok(result);
    }
}