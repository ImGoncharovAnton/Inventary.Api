﻿using Inventary.Domain.Entities;
using Inventary.Domain.Enums;

namespace Inventary.Services.Models.DTO;

public class CreateItemDto
{
    public string ItemName { get; set; }
    public DateTime? UserDate { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public double Price { get; set; }
    public Guid? RoomId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CurrentCategoryId { get; set; }
    public Guid? SetupId { get; set; }
    public List<CreateItemPhotoDto>? ItemPhotos { get; set; }
    public List<CreateAttachementDto>? Attachments { get; set; }
    public List<CreateDefectDto>? Defects { get; set; }
    public List<CreateCommentDto>? Comments { get; set; }
}