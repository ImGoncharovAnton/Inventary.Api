﻿using Inventary.Domain.Entities;
using Inventary.Domain.Enums;
using Inventary.Services.Models.DTO;

namespace Inventary.Web.Models.Request;

public class UserRequestUi
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public List<Item>? Items { get; set; }
    public string urlOrig { get; set; }
    public string urlCrop { get; set; }
    public Guid? CurrentSetupId { get; set; }
    
}