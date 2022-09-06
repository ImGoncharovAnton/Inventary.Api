using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface ISetupService
{
    Task<IList<SetupDto>> GetAllItems();
    Task<IList<SetupDto>> GetAllSetupsWithoutUser();
    Task<IList<SetupsListWithNumberOfDefects>> GetAllWithNumberOfDefects();
    Task<IList<SetupsListForSelect>> GetAllSetupsForSelect();
    Task<IList<SetupsListWithNumberOfDefects>> GetAllSetupsForRoomById(Guid id);
    Task<SetupDto> GetByIdAsync(Guid id);
    Task<SetupDto> CreateAsync(CreateSetupDto item);
    Task<bool> UpdateAsync(Guid id, UpdateSetupDto item);
    Task<bool> ToggleSetupStatus(Guid id, SetupForUpdateStatusDto setup);
    Task ToggleSetupStatusList(IList<SetupForUpdateStatusDto> setups);
    Task MoveSetupsToAnotherRoom(Guid id, IList<ListMoveSetupsDto> items);
    Task<bool> DeleteAsync(Guid id);
}