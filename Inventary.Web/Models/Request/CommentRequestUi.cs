﻿namespace Inventary.Web.Models.Request;

public class CommentRequestUi
{
    public string CommentDescription { get; set; }
    public Guid ItemId { get; set; }
    public DateTime UserDate { get; set; }
    public bool IsEdit { get; set; }
}