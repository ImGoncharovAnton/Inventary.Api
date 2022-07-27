﻿using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface ISetupService
{
    Task<IList<SetupDto>> GetAllItems();
    Task<IList<SetupsListWithNumberOfDefects>> GetAllWithNumberOfDefects();
    Task<IList<SetupsListWithNumberOfDefects>> GetAllSetupsForRoomById(Guid id);
    Task<SetupDto> GetByIdAsync(Guid id);
    Task<SetupDto> CreateAsync(CreateSetupDto item);
    Task UpdateAsync(Guid id, UpdateSetupDto item);
    Task DeleteAsync(Guid id);
}