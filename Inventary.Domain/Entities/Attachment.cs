﻿namespace Inventary.Domain.Entities;

public class Attachment: BaseEntity
{
    public string FileName { get; set; }
    public int FileSize { get; set; }
    public string FileType { get; set; }
    public string FileUrl { get; set; }
    public Guid ItemId { get; set; }
    public virtual Item Item { get; set; }
}