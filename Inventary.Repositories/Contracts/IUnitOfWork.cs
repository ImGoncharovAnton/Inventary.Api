namespace Inventary.Repositories.Contracts;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    // Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}