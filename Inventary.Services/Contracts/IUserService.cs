using Inventary.Repositories.Common.Models;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Contracts;

public interface IUserService
{
    Task<IList<UserDto>> GetAllAsync();
    Task<IList<ListUsersForCreateSetup>> GetListUsersForCreateSetup();
    Task<UserDto> GetByIdAsync(Guid id);
    Task<UserDto> CreateAsync(UserCreateDto user);
    Task<bool> UpdateAsync(Guid id, UserCreateDto user);
    Task<bool> DeleteAsync(Guid id);
}