using Inventary.Domain.Entities;
using Inventary.Domain.Enums;
using Inventary.Services.Models.DTO;

namespace Inventary.Tests.MockData;

public class UserMockData
{
    public static List<User> GetUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = new Guid("336F87B0-8912-4C67-A0CC-D0FA59DEAE3D"),
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                FirstName = "FirstName 1",
                LastName = "LastName 1",
                Phone = "123",
                Email = "email 1",
                Status = StatusEnum.StatusType.Active,
                urlCrop = "",
                urlOrig = "",
                Items = null,
                CurrentSetupId = null
            },
            new User
            {
                Id = new Guid("ADDB5810-35E3-4A76-B3B2-C9F2E02DA820"),
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                FirstName = "FirstName 2",
                LastName = "LastName 2",
                Phone = "1233",
                Email = "email 2",
                Status = StatusEnum.StatusType.Active,
                urlCrop = "",
                urlOrig = "",
                Items = null,
                CurrentSetupId = null
            },
            new User
            {
                Id = new Guid("63698479-1A54-49E2-9FBF-34A5003C9148"),
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                FirstName = "FirstName 3",
                LastName = "LastName 3",
                Phone = "3533",
                Email = "email 3",
                Status = StatusEnum.StatusType.Inactive,
                urlCrop = "",
                urlOrig = "",
                Items = null,
                CurrentSetupId = new Guid("489FB9AA-471F-41FE-B591-A4C27246BB08")
            }
        };
    }

    public static UserCreateDto UserCreateDto()
    {
        return new UserCreateDto
        {
            FirstName = "NewFirstName",
            LastName = "NewLastName",
            Phone = "239492-3432",
            Email = "emal@asd.as",
            Status = StatusEnum.StatusType.Active,
            urlCrop = "",
            urlOrig = "",
            CurrentSetupId = new Guid("D7179B4A-59A9-4D68-ABCB-7E06D2EB66B1"),
            Items = null
        };
    }
}