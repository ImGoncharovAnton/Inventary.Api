﻿using Inventary.Domain.Entities;
using Inventary.Domain.Enums;
using Inventary.Services.Models.DTO;

namespace Inventary.Web.Models.Response;

public class UserResponseUi
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public StatusEnum.StatusType Status { get; set; }
    public string urlOrig { get; set; }
    public string urlCrop { get; set; }
    public List<Item>? Items { get; set; }
    public Guid? CurrentSetupId { get; set; }
    public string SetupName { get; set; }
}