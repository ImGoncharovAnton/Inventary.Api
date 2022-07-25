using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;

namespace Inventary.Repositories.Repositories;

public class CommentRepository: GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext dbContext): base(dbContext)
    {
        
    }
}