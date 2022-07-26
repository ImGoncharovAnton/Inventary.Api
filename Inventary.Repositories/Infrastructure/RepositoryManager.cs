using Inventary.Domain.Entities;
using Inventary.Repositories.Contracts;
using Inventary.Repositories.Repositories;

namespace Inventary.Repositories.Infrastructure;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IRoomRepository> _lazyRoomRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
    private readonly Lazy<IUserRepository> _lazyUserRepository;
    private readonly Lazy<IItemRepository<Item>> _lazyItemRepository;
    private readonly Lazy<ICategoryRepository> _lazyCategoryRepository;
    private readonly Lazy<IItemPhotoRepository> _lazyItemPhotoRepository;
    private readonly Lazy<IAttachmentRepository> _lazyAttachmentRepository;
    private readonly Lazy<ICommentRepository> _lazyCommentRepository;
    private readonly Lazy<IDefectRepository> _lazyDefectRepository;
    private readonly Lazy<IDefectPhotoRepository> _lazyDefectPhotoRepository;
    private readonly Lazy<ISetupRepository> _lazySetupRepository;

    public RepositoryManager(ApplicationDbContext dbContext)
    {
        _lazyRoomRepository = new Lazy<IRoomRepository>(() => new RoomRepository(dbContext));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
        _lazyItemRepository = new Lazy<IItemRepository<Item>>(() => new ItemRepository(dbContext));
        _lazyCategoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(dbContext));
        _lazyItemPhotoRepository = new Lazy<IItemPhotoRepository>(() => new ItemPhotoRepository(dbContext));
        _lazyAttachmentRepository = new Lazy<IAttachmentRepository>(() => new AttachmentRepository(dbContext));
        _lazyCommentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(dbContext));
        _lazyDefectRepository = new Lazy<IDefectRepository>(() => new DefectRepository(dbContext));
        _lazyDefectPhotoRepository = new Lazy<IDefectPhotoRepository>(() => new DefectPhotoRepository(dbContext));
        _lazySetupRepository = new Lazy<ISetupRepository>(() => new SetupRepository(dbContext));
    }

    public IRoomRepository RoomRepository => _lazyRoomRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    public IUserRepository UserRepository => _lazyUserRepository.Value;
    public IItemRepository<Item> ItemRepository => _lazyItemRepository.Value;
    public ICategoryRepository CategoryRepository => _lazyCategoryRepository.Value;
    public IItemPhotoRepository ItemPhotoRepository => _lazyItemPhotoRepository.Value;
    public IAttachmentRepository AttachmentRepository => _lazyAttachmentRepository.Value;
    public ICommentRepository CommentRepository => _lazyCommentRepository.Value;
    public IDefectRepository DefectRepository => _lazyDefectRepository.Value;
    public IDefectPhotoRepository DefectPhotoRepository => _lazyDefectPhotoRepository.Value;
    public ISetupRepository SetupRepository => _lazySetupRepository.Value;
}