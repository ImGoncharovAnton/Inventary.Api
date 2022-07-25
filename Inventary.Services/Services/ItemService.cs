using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
using Inventary.Services.Extensions;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Services;

public class ItemService : IItemService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;


    public ItemService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IList<ItemDto>> GetAllItems()
    {
        var items = await _repositoryManager.ItemRepository.GetAllAsync();
        var result = _mapper.Map<List<ItemDto>>(items);
        return result;
    }

    public async Task<ItemDto> GetByIdAsync(Guid id)
    {
        var item = await _repositoryManager.ItemRepository.GetByIdAsync(id);
        if (item is null)
            throw new ItemNotFoundException(id);
        var result = _mapper.Map<ItemDto>(item);

        return result;
    }

    public async Task<ItemDto> CreateAsync(CreateItemDto createItem)
    {
        var item = _mapper.Map<Item>(createItem);

        var result = _mapper.Map<ItemDto>(item);

        await _repositoryManager.ItemRepository.Add(item);

        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return result;
    }

    public async Task<ItemDto> UpdateAsync(Guid id, UpdateItemDto item)
    {
        var deciredItem = await _repositoryManager.ItemRepository.GetByIdAsync(id);
        if (deciredItem is null)
            throw new ItemNotFoundException(id);

        deciredItem.UpdateDate = DateTime.UtcNow;
        deciredItem.ItemName = item.ItemName;
        deciredItem.UserDate = item.UserDate;
        deciredItem.Status = item.Status;
        deciredItem.Price = item.Price;
        deciredItem.QRcode = item.QRcode;
        deciredItem.RoomId = item.RoomId;
        deciredItem.UserId = item.UserId;
        deciredItem.CurrentCategoryId = item.CurrentCategoryId;
        // deciredItem.ItemPhotos = mappedItemPhotos;
        // deciredItem.Attachments = mappedAttachments;
        // deciredItem.Defects = mappedDefects;
        // deciredItem.Comments = mappedComment;

        // foreach (var deciredItemPhoto in deciredItem.ItemPhotos)
        // {
        //     _repositoryManager.ItemPhotoRepository.Remove(deciredItemPhoto);
        //     // _repositoryManager.ItemPhotoRepository.Upsert(deciredItemPhoto);
        //     // await _repositoryManager.UnitOfWork.SaveChangesAsync();
        // }

        #region InsertItemPhotos

        var mappedItemPhotos = _mapper.Map<List<ItemPhoto>>(item.ItemPhotos);

        // if (item.ItemPhotos.Count() < deciredItem.ItemPhotos.Count())

        var deleteItemPhotosList = deciredItem.ItemPhotos
                .ExceptBy(mappedItemPhotos.Select(x => x.Id), z => z.Id).ToList();
        foreach (var delItemPhoto in deleteItemPhotosList)
        {
            _repositoryManager.ItemPhotoRepository.Remove(delItemPhoto);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }


        foreach (var mappedItemPhoto in mappedItemPhotos)
        {
            var findItemPhoto = await _repositoryManager.ItemPhotoRepository.GetByIdAsync(mappedItemPhoto.Id);
            if (findItemPhoto is not null)
            {
                findItemPhoto.OrigUrl = mappedItemPhoto.OrigUrl;
                findItemPhoto.UpdateDate = DateTime.UtcNow;
            }
            else
            {
                var newItemPhoto = new ItemPhoto()
                {
                    CreatedDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                    ItemId = id,
                    OrigUrl = mappedItemPhoto.OrigUrl
                };
                _repositoryManager.ItemPhotoRepository.Add(newItemPhoto);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }
        }

        #endregion


        #region InsertAttachments

        var mappedAttachments = _mapper.Map<List<Attachment>>(item.Attachments);
        if (deciredItem.Attachments is not null)
        {
            var deleteAttachmentsList = deciredItem.Attachments
                .ExceptBy(mappedAttachments.Select(x => x.Id), z => z.Id).ToList();

            foreach (var deletedItem in deleteAttachmentsList)
            {
                _repositoryManager.AttachmentRepository.Remove(deletedItem);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }
        }
        
        foreach (var mappedItem in mappedAttachments)
        {
            var findItem = await _repositoryManager.AttachmentRepository.GetByIdAsync(mappedItem.Id);
            if (findItem is not null)
            {
                findItem.UpdateDate = DateTime.UtcNow;
                findItem.FileName = mappedItem.FileName;
                findItem.FileSize = mappedItem.FileSize;
                findItem.FileType = mappedItem.FileType;
                findItem.FileUrl = mappedItem.FileUrl;
            }
            else
            {
                var newAttachmentItem = new Attachment()
                {
                    CreatedDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                    FileName = mappedItem.FileName,
                    FileSize = mappedItem.FileSize,
                    FileType = mappedItem.FileType,
                    FileUrl = mappedItem.FileUrl,
                    ItemId = id
                };
                _repositoryManager.AttachmentRepository.Add(newAttachmentItem);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }
        }

        #endregion

        #region InsertDefects

        var mappedDefects = _mapper.Map<List<Defect>>(item.Defects);

        if (deciredItem.Defects is not null)
        {
            var deleteDefectsList = deciredItem.Defects
                .ExceptBy(mappedDefects.Select(x => x.Id), z => z.Id).ToList();

            foreach (var deletedItem in deleteDefectsList)
            {
                _repositoryManager.DefectRepository.Remove(deletedItem);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }

            foreach (var mappedItem in mappedDefects)
            {
                var findItem = await _repositoryManager.DefectRepository.GetByIdAsync(mappedItem.Id);
                if (findItem is not null)
                {
                    findItem.UpdateDate = DateTime.UtcNow;
                    findItem.DefectName = mappedItem.DefectName;
                    findItem.DefectDescription = mappedItem.DefectDescription;
                    // findItem.DefectPhotos =
                    var deleteDefectPhotosList = deciredItem.Defects
                        .SelectMany(x => x.DefectPhotos)
                        .ExceptBy(mappedDefects.SelectMany(x => x.DefectPhotos)
                            .Select(x => x.Id), z => z.Id).ToList();
                    foreach (var deletedItemDefectPhoto in deleteDefectPhotosList)
                    {
                        _repositoryManager.DefectPhotoRepository.Remove(deletedItemDefectPhoto);
                        await _repositoryManager.UnitOfWork.SaveChangesAsync();
                    }
                }
                else
                {
                    
                    var newDefectItem = new Defect()
                    {
                        CreatedDate = DateTime.UtcNow,
                        UpdateDate = DateTime.UtcNow,
                        DefectName = mappedItem.DefectName,
                        DefectDescription = mappedItem.DefectDescription,

                    };
                }
            }
        }
       

        #endregion
        // Подумать как добавить лист дефетных фото
        
        #region InsertComment
        
        var mappedComments = _mapper.Map<List<Comment>>(item.Comments);

        var deleteCommentsList = deciredItem.Comments
            .ExceptBy(mappedComments.Select(x => x.Id), z => z.Id).ToList();

        foreach (var deletedItem in deleteCommentsList)
        {
            _repositoryManager.CommentRepository.Remove(deletedItem);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        foreach (var mappedItem in mappedComments)
        {
            var findComment = await _repositoryManager.CommentRepository.GetByIdAsync(mappedItem.Id);
            if (findComment is not null)
            {
                findComment.UpdateDate = DateTime.UtcNow;
                findComment.CommentDescription = mappedItem.CommentDescription;
            }
            else
            {
                var newItemComment = new Comment()
                {
                    CreatedDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                    ItemId = id,
                    CommentDescription = mappedItem.CommentDescription
                };
                _repositoryManager.CommentRepository.Add(newItemComment);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }
        }

        #endregion

        // foreach (var itemPhoto in mappedItemPhotos)
        // {
        //     _repositoryManager.ItemPhotoRepository.Upsert(itemPhoto);
        //     // await _repositoryManager.UnitOfWork.SaveChangesAsync();
        // }


        // await _repositoryManager.ItemRepository.Update(deciredItem);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();

        var result = _mapper.Map<ItemDto>(deciredItem);
        return result;
    }

    public async Task Upsert(Guid id, CreateItemDto item)
    {
        var deciredItem = await _repositoryManager.ItemRepository.GetByIdAsync(id);
        if (deciredItem is null)
            throw new ItemNotFoundException(id);

        var mappedItem = _mapper.Map<Item>(item);
        _repositoryManager.ItemRepository.Upsert(mappedItem);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }


    public async Task<ItemDto> DeleteAsync(Guid id)
    {
        var item = await _repositoryManager.ItemRepository.GetByIdAsync(id);
        if (item is null)
            throw new ItemNotFoundException(id);

        _repositoryManager.ItemRepository.Remove(item);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();

        var result = _mapper.Map<ItemDto>(item);
        return result;
    }
}