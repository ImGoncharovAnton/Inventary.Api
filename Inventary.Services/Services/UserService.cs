using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
using Inventary.Services.Extensions;
using Inventary.Services.Models.DTO;

namespace Inventary.Services.Services;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public UserService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IList<UserDto>> GetAllAsync()
    {
        var users = await _repositoryManager.UserRepository.GetAllUsers();
        var result = _mapper.Map<List<UserDto>>(users);
        return result;
    }

    public async Task<IList<ListUsersForCreateSetup>> GetListUsersForCreateSetup()
    {
        return await _repositoryManager.UserRepository.GetUsersListForCreateSetups();
    }

    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        var user = await _repositoryManager.UserRepository.GetUserByIdWithSetup(id);
        if (user is null)
            throw new UserNotFoundException(id);
        var result = _mapper.Map<UserDto>(user);

        return result;
    }

    public async Task<UserDto> CreateAsync(UserCreateDto createUser)
    {
        var user = _mapper.Map<User>(createUser);
        var result = _mapper.Map<UserDto>(user);
        var newUser = _repositoryManager.UserRepository.AddAsync(user);
        if (user.CurrentSetupId is not null)
        {
            var findSetup = await _repositoryManager.SetupRepository.GetByIdWithItemsAsync(user.CurrentSetupId.Value);
            findSetup.UpdateDate = DateTime.UtcNow;
            findSetup.UserId = newUser.Result.Id;
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return result;
    }

    public async Task<bool> UpdateAsync(Guid id, UserCreateDto user)
    {
        var desiredUser = await _repositoryManager.UserRepository.GetByIdAsync(id);
        if (desiredUser is null)
            throw new UserNotFoundException(id);

        desiredUser.UpdateDate = DateTime.UtcNow;
        desiredUser.FirstName = user.FirstName;
        desiredUser.LastName = user.LastName;
        desiredUser.Phone = user.Phone;
        desiredUser.Email = user.Email;
        desiredUser.Status = user.Status;
        desiredUser.urlOrig = user.urlOrig;
        desiredUser.urlCrop = user.urlCrop;

        if (desiredUser.CurrentSetupId != user.CurrentSetupId)
        {
            if (desiredUser.CurrentSetupId is not null)
            {
                var findSetup =
                    await _repositoryManager.SetupRepository.GetByIdWithItemsAsync(desiredUser.CurrentSetupId.Value);
                findSetup.UpdateDate = DateTime.UtcNow;
                findSetup.UserId = null;
                findSetup.User = null;
                await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }

            if (user.CurrentSetupId is not null)
            {
                var findSetup =
                    await _repositoryManager.SetupRepository.GetByIdWithItemsAsync(user.CurrentSetupId.Value);
                findSetup.UpdateDate = DateTime.UtcNow;
                findSetup.UserId = id;
                await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }

            desiredUser.CurrentSetupId = user.CurrentSetupId;
        }


        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(id);
        if (user is null)
            throw new UserNotFoundException(id);
        
        if (user.CurrentSetupId is { } or { })
        {
            var setup = await _repositoryManager.SetupRepository.GetByIdWithItemsAsync(user.CurrentSetupId.Value);
            setup.User = null;
            setup.UserId = null;
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        _repositoryManager.UserRepository.Remove(user);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return true;
    }
}