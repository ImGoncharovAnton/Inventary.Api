using Inventary.Repositories.Contracts;

namespace Inventary.Repositories.Repositories;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync() =>
        _dbContext.SaveChangesAsync();
}