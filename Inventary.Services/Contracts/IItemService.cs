using Inventary.Repositories.Common.Models;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface IItemService
{
    Task<IList<ListItemsForStorage>> GetAllItems();
    Task<ListItemsForStorageResponse> GetItemsByPage(int page);
    Task<IList<ItemsList>> GetItemsListAsync();
    Task<IList<ItemsList>> GetItemsListBySetupId(Guid id);
    Task<ItemDto> GetByIdAsync(Guid id);
    Task<ItemDto> CreateAsync(CreateItemDto item);
    Task<ItemDto> UpdateAsync(Guid id, UpdateItemDto item);
    Task MoveItemsToAnotherRoom(Guid id, IList<ListItemsForUpdate> items);
    Task<ItemDto> DeleteAsync(Guid id);
    Task DeleteRange(IList<ItemsForRoom> items);
}