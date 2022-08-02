using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Domain.Enums;
using Inventary.Repositories.Common.Models;
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

    public async Task<IList<ItemsList>> GetItemsListAsync()
    {
        return await _repositoryManager.ItemRepository.GetListItemsAsync();
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
        var desiredItem = await _repositoryManager.ItemRepository.GetByIdAsync(id);
        if (desiredItem is null)
            throw new ItemNotFoundException(id);
        var mappedAttachments = _mapper.Map<List<Attachment>>(item.Attachments);
        var mappedItemPhotos = _mapper.Map<List<ItemPhoto>>(item.ItemPhotos);
        var mappedDefects = _mapper.Map<List<Defect>>(item.Defects);
        var mappedComments = _mapper.Map<List<Comment>>(item.Comments);
        desiredItem.UpdateDate = DateTime.UtcNow;
        desiredItem.ItemName = item.ItemName;
        desiredItem.UserDate = item.UserDate;
        desiredItem.Status = item.Status;
        desiredItem.Price = item.Price;
        desiredItem.QRcode = item.QRcode;
        desiredItem.RoomId = item.RoomId;
        desiredItem.UserId = item.UserId;
        desiredItem.CurrentCategoryId = item.CurrentCategoryId;
        desiredItem.SetupId = item.SetupId;
        desiredItem.ItemPhotos = mappedItemPhotos;
        desiredItem.Attachments = mappedAttachments;
        desiredItem.Defects = mappedDefects;
        desiredItem.Comments = mappedComments;

        // #region InsertItemPhotos
        //
        // var mappedItemPhotos = _mapper.Map<List<ItemPhoto>>(item.ItemPhotos);
        //
        // // if (item.ItemPhotos.Count() < deciredItem.ItemPhotos.Count())
        //
        // var deleteItemPhotosList = deciredItem.ItemPhotos
        //         .ExceptBy(mappedItemPhotos.Select(x => x.Id), z => z.Id).ToList();
        // foreach (var delItemPhoto in deleteItemPhotosList)
        // {
        //     _repositoryManager.ItemPhotoRepository.Remove(delItemPhoto);
        //     await _repositoryManager.UnitOfWork.SaveChangesAsync();
        // }
        //
        //
        // foreach (var mappedItemPhoto in mappedItemPhotos)
        // {
        //     var findItemPhoto = await _repositoryManager.ItemPhotoRepository.GetByIdAsync(mappedItemPhoto.Id);
        //     if (findItemPhoto is not null)
        //     {
        //         findItemPhoto.OrigUrl = mappedItemPhoto.OrigUrl;
        //         findItemPhoto.UpdateDate = DateTime.UtcNow;
        //     }
        //     else
        //     {
        //         var newItemPhoto = new ItemPhoto()
        //         {
        //             CreatedDate = DateTime.UtcNow,
        //             UpdateDate = DateTime.UtcNow,
        //             ItemId = id,
        //             OrigUrl = mappedItemPhoto.OrigUrl
        //         };
        //         _repositoryManager.ItemPhotoRepository.Add(newItemPhoto);
        //         await _repositoryManager.UnitOfWork.SaveChangesAsync();
        //     }
        // }
        //
        // #endregion
        //
        //
        // #region InsertAttachments
        //
        // var mappedAttachments = _mapper.Map<List<Attachment>>(item.Attachments);
        // if (deciredItem.Attachments is not null)
        // {
        //     var deleteAttachmentsList = deciredItem.Attachments
        //         .ExceptBy(mappedAttachments.Select(x => x.Id), z => z.Id).ToList();
        //
        //     foreach (var deletedItem in deleteAttachmentsList)
        //     {
        //         _repositoryManager.AttachmentRepository.Remove(deletedItem);
        //         await _repositoryManager.UnitOfWork.SaveChangesAsync();
        //     }
        // }
        //
        // foreach (var mappedItem in mappedAttachments)
        // {
        //     var findItem = await _repositoryManager.AttachmentRepository.GetByIdAsync(mappedItem.Id);
        //     if (findItem is not null)
        //     {
        //         findItem.UpdateDate = DateTime.UtcNow;
        //         findItem.FileName = mappedItem.FileName;
        //         findItem.FileSize = mappedItem.FileSize;
        //         findItem.FileType = mappedItem.FileType;
        //         findItem.FileUrl = mappedItem.FileUrl;
        //     }
        //     else
        //     {
        //         var newAttachmentItem = new Attachment()
        //         {
        //             CreatedDate = DateTime.UtcNow,
        //             UpdateDate = DateTime.UtcNow,
        //             FileName = mappedItem.FileName,
        //             FileSize = mappedItem.FileSize,
        //             FileType = mappedItem.FileType,
        //             FileUrl = mappedItem.FileUrl,
        //             ItemId = id
        //         };
        //         _repositoryManager.AttachmentRepository.Add(newAttachmentItem);
        //         await _repositoryManager.UnitOfWork.SaveChangesAsync();
        //     }
        // }
        //
        // #endregion
        //
        // #region InsertDefects
        //
        // var mappedDefects = _mapper.Map<List<Defect>>(item.Defects);
        //
        // if (deciredItem.Defects is not null)
        // {
        //     var deleteDefectsList = deciredItem.Defects
        //         .ExceptBy(mappedDefects.Select(x => x.Id), z => z.Id).ToList();
        //
        //     foreach (var deletedItem in deleteDefectsList)
        //     {
        //         _repositoryManager.DefectRepository.Remove(deletedItem);
        //         await _repositoryManager.UnitOfWork.SaveChangesAsync();
        //     }
        //
        //     foreach (var mappedItem in mappedDefects)
        //     {
        //         
        //         var findItem = await _repositoryManager.DefectRepository.GetByIdAsync(mappedItem.Id);
        //         if (findItem is not null)
        //         {
        //             findItem.UpdateDate = DateTime.UtcNow;
        //             findItem.DefectName = mappedItem.DefectName;
        //             findItem.DefectDescription = mappedItem.DefectDescription;
        //             // findItem.DefectPhotos =
        //             var deleteDefectPhotosList = deciredItem.Defects
        //                 .SelectMany(x => x.DefectPhotos)
        //                 .ExceptBy(mappedDefects.SelectMany(x => x.DefectPhotos)
        //                     .Select(x => x.Id), z => z.Id).ToList();
        //             foreach (var deletedItemDefectPhoto in deleteDefectPhotosList)
        //             {
        //                 _repositoryManager.DefectPhotoRepository.Remove(deletedItemDefectPhoto);
        //                 await _repositoryManager.UnitOfWork.SaveChangesAsync();
        //             }
        //
        //             var defectPhotoList = mappedItem.DefectPhotos;
        //             if (defectPhotoList is null) continue;
        //             foreach (var defectPhoto in defectPhotoList)
        //             {
        //                 if (defectPhoto.Id == default(Guid))
        //                 {
        //                     var newDefectPhoto = new DefectPhoto()
        //                     {
        //                         CreatedDate = DateTime.UtcNow,
        //                         UpdateDate = DateTime.UtcNow,
        //                         OrigUrl = defectPhoto.OrigUrl,
        //                         DefectId = mappedItem.Id
        //                     };
        //                     _repositoryManager.DefectPhotoRepository.Add(newDefectPhoto);
        //                     await _repositoryManager.UnitOfWork.SaveChangesAsync();
        //                 }
        //             }
        //
        //             // Тут пишем условие if default id(guid) == 0 то бежим циклом по листу деффектов, удовлетворяющих условию, создаем новый деффект,
        //             // и присваиваем ему defectId = findItem.Id
        //         }
        //         else
        //         {
        //             var newDefectItem = new Defect()
        //             {
        //                 CreatedDate = DateTime.UtcNow,
        //                 UpdateDate = DateTime.UtcNow,
        //                 DefectName = mappedItem.DefectName,
        //                 DefectDescription = mappedItem.DefectDescription,
        //                 ItemId = id
        //             };
        //             var newDef = await _repositoryManager.DefectRepository.AddAsync(newDefectItem);
        //             var defectPhotoList = mappedItem.DefectPhotos;
        //             foreach (var defectPhoto in defectPhotoList)
        //             {
        //                 var findDefectPhoto = await _repositoryManager.DefectPhotoRepository
        //                     .GetByIdAsync(defectPhoto.Id);
        //                 if (findDefectPhoto is null)
        //                 {
        //                     var newDefectPhoto = new DefectPhoto()
        //                     {
        //                         CreatedDate = DateTime.UtcNow,
        //                         UpdateDate = DateTime.UtcNow,
        //                         OrigUrl = defectPhoto.OrigUrl,
        //                         DefectId = newDef.Id
        //                     };
        //                     _repositoryManager.DefectPhotoRepository.Add(newDefectPhoto);
        //                     await _repositoryManager.UnitOfWork.SaveChangesAsync();
        //                 }
        //             }
        //             
        //         }
        //     }
        // }
        //
        //
        // #endregion
        // // Подумать как добавить лист дефетных фото
        //
        // #region InsertComment
        //
        // var mappedComments = _mapper.Map<List<Comment>>(item.Comments);
        //
        // var deleteCommentsList = deciredItem.Comments
        //     .ExceptBy(mappedComments.Select(x => x.Id), z => z.Id).ToList();
        //
        // foreach (var deletedItem in deleteCommentsList)
        // {
        //     _repositoryManager.CommentRepository.Remove(deletedItem);
        //     await _repositoryManager.UnitOfWork.SaveChangesAsync();
        // }
        //
        // foreach (var mappedItem in mappedComments)
        // {
        //     var findComment = await _repositoryManager.CommentRepository.GetByIdAsync(mappedItem.Id);
        //     if (findComment is not null)
        //     {
        //         findComment.UpdateDate = DateTime.UtcNow;
        //         findComment.CommentDescription = mappedItem.CommentDescription;
        //     }
        //     else
        //     {
        //         var newItemComment = new Comment()
        //         {
        //             CreatedDate = DateTime.UtcNow,
        //             UpdateDate = DateTime.UtcNow,
        //             ItemId = id,
        //             CommentDescription = mappedItem.CommentDescription
        //         };
        //         _repositoryManager.CommentRepository.Add(newItemComment);
        //         await _repositoryManager.UnitOfWork.SaveChangesAsync();
        //     }
        // }
        //
        // #endregion

        // foreach (var itemPhoto in mappedItemPhotos)
        // {
        //     _repositoryManager.ItemPhotoRepository.Upsert(itemPhoto);
        //     // await _repositoryManager.UnitOfWork.SaveChangesAsync();
        // }


        // await _repositoryManager.ItemRepository.Update(deciredItem);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();

        var result = _mapper.Map<ItemDto>(desiredItem);
        return result;
    }

    public async Task MoveItemsToAnotherRoom(Guid id, IList<ListItemsForUpdate> items)
    {
        var desiredRoom = await _repositoryManager.RoomRepository.GetByIdAsync(id);
        if (desiredRoom is null)
            throw new RoomNotFoundException(id);

        var itemsList = items.ToList();
        // Можно ли это оптимизировать? Мб отправлять массив на апдейт? И как тогда менять значения...
        if (itemsList is not null)
        {
            foreach (var item in itemsList)
            {
                var findItem = await _repositoryManager.ItemRepository.GetByIdAsync(item.Id);
                if (findItem is null) continue;
                findItem.UpdateDate = DateTime.UtcNow;
                findItem.RoomId = id;
                findItem.SetupId = null;
                findItem.Setup = null;
                findItem.Status = StatusEnum.StatusType.Active;
                await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }
        }
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