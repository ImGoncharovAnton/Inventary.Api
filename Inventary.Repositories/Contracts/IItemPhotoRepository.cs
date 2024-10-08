﻿using Inventary.Domain.Entities;

namespace Inventary.Repositories.Contracts;

public interface IItemPhotoRepository: IGenericRepository<ItemPhoto>
{
    void Upsert(ItemPhoto entity);
}