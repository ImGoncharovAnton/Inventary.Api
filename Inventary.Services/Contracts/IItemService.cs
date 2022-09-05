using Inventary.Repositories.Common.Models;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface IItemService
{
    Task<IList<ListItemsForStorage>> GetAllItems();
    Task<ListItemsForStorageResponse> GetItemsByPage(RequestParams parameters);
    Task<IList<ItemsList>> GetItemsListAsync();
    Task<IList<ItemsList>> GetItemsListBySetupId(Guid id);
    Task<ItemDto> GetByIdAsync(Guid id);
    Task<ItemDto> CreateAsync(CreateItemDto item);
    Task<ItemDto> UpdateAsync(Guid id, UpdateItemDto item);
    Task<bool> MoveItemsToAnotherRoom(Guid id, IList<ListItemsForUpdate> items);
    Task<ItemDto> DeleteAsync(Guid id);
    Task<bool> DeleteRange(IList<ItemsForRoom> items);
}