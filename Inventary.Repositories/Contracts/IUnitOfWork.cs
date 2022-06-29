namespace Inventary.Repositories.Contracts;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}