using Inventary.Repositories.Common.Models;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface IItemService
{
    Task<IList<ItemDto>> GetAllItems();
    Task<IList<ItemsList>> GetItemsListAsync();
    Task<ItemDto> GetByIdAsync(Guid id);
    Task<ItemDto> CreateAsync(CreateItemDto item);
    Task<ItemDto> UpdateAsync(Guid id, UpdateItemDto item);
    Task MoveItemsToAnotherRoom(Guid id, IList<ListItemsForUpdate> items);
    Task<ItemDto> DeleteAsync(Guid id);
}