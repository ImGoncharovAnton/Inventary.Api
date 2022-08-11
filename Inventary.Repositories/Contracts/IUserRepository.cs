using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;

namespace Inventary.Repositories.Contracts;

public interface IUserRepository: IGenericRepository<User>
{
    Task<IList<User>> GetAllUsers();
    Task<List<ListUsersForCreateSetup>> GetUsersListForCreateSetups();
    Task<User> GetUserByIdWithSetup(Guid id);
    Task<User> AddAsync(User entity);
    Task<string> ValidateEmail(string email);
}