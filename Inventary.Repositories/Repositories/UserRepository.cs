using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Repositories.Repositories;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<ListUsersForCreateSetup>> GetUsersListForCreateSetups()
    {
        // User who haven't Setup
        return await _dbContext.Users.Where(x => x.CurrentSetupId == null).Select(u => new ListUsersForCreateSetup()
        {
            Id = u.Id,
            FullName = u.FirstName + " " + u.LastName
        }).ToListAsync();
    }
}