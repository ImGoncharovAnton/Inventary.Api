﻿namespace Inventary.Services.Models.DTO;

public class UpdateCommentDto
{
    public Guid? Id { get; set; }
    public string CommentDescription { get; set; }
    public Guid ItemId { get; set; }
    public DateTime UserDate { get; set; }
    public bool IsEdit { get; set; }
}