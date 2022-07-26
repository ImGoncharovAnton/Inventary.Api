using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;

namespace Inventary.Repositories.Infrastructure;

public interface IRepositoryManager
{
    IUnitOfWork UnitOfWork { get; }
    IRoomRepository RoomRepository { get; }
    IUserRepository UserRepository { get; }
    IItemRepository<Item> ItemRepository { get; } 
    ICategoryRepository CategoryRepository { get; }
    IItemPhotoRepository ItemPhotoRepository { get; }
    IAttachmentRepository AttachmentRepository { get; }
    ICommentRepository CommentRepository { get; }
    IDefectRepository DefectRepository { get; }
    IDefectPhotoRepository DefectPhotoRepository { get; }
    ISetupRepository SetupRepository { get; }
}