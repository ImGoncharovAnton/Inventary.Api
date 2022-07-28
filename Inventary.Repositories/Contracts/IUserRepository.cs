using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;

namespace Inventary.Repositories.Contracts;

public interface IUserRepository: IGenericRepository<User>
{
    Task<List<ListUsersForCreateSetup>> GetUsersListForCreateSetups();
}