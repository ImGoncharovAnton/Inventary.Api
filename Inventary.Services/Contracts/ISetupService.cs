using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface ISetupService
{
    Task<IList<SetupDto>> GetAllItems();
    Task<SetupDto> GetByIdAsync(Guid id);
    Task<SetupDto> CreateAsync(CreateSetupDto item);
    Task UpdateAsync(Guid id, UpdateSetupDto item);
    Task DeleteAsync(Guid id);
}