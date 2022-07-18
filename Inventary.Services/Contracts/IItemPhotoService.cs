using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface IItemPhotoService
{
    Task<IList<ItemPhotoDto>> GetAllAsync();
    Task<ItemPhotoDto> GetByIdAsync(Guid id);
    Task<ItemPhotoDto> CreateAsync(CreateItemPhotoDto itemPhoto);
    Task UpdateAsync(Guid id, CreateItemPhotoDto itemPhoto);
    Task DeleteAsync(Guid id);
}