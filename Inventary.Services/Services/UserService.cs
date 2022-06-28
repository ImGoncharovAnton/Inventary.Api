using AutoMapper;
using Inventary.Domain.Entities;
using Inventary.Domain.Extensions;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Contracts;
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
        var users = await _repositoryManager.UserRepository.GetAllAsync();
        var result = _mapper.Map<List<UserDto>>(users);
        return result;
    }

    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(id);
        if (user is null)
            throw new UserNotFoundException(id);
        var result = _mapper.Map<UserDto>(user);

        return result;
    }

    public async Task<UserDto> CreateAsync(UserCreateDto createUser)
    {
        var user = _mapper.Map<User>(createUser);
        var result = _mapper.Map<UserDto>(user);
        
        _repositoryManager.UserRepository.Add(user);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        return result;
    }

    public async Task UpdateAsync(Guid id, UserCreateDto user)
    {
        var deciredUser = await _repositoryManager.UserRepository.GetByIdAsync(id);
        if (deciredUser is null)
            throw new UserNotFoundException(id);
        
        deciredUser.UpdateDate = DateTime.UtcNow;
        deciredUser.FirstName = user.FirstName;
        deciredUser.LastName = user.LastName;
        deciredUser.Phone = user.Phone;
        deciredUser.Email = user.Email;
        deciredUser.Status = user.Status;
        // deciredUser.Items = user.Items;
        // deciredUser.SetupId = user.SetupId;

        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(id);
        if (user is null)
            throw new RoomNotFoundException(id);
        
        _repositoryManager.UserRepository.Remove(user);
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }
}