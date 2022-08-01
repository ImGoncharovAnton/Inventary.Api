using Inventary.Domain.Entities;
using Inventary.Repositories.Common.Models;
using Inventary.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Repositories.Repositories;

public class SetupRepository: GenericRepository<Setup>, ISetupRepository
{
    private readonly ApplicationDbContext _dbContext;
    public SetupRepository(ApplicationDbContext dbContext): base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Setup> AddAsync(Setup entity)
    {
        await _dbContext.Setups.AddAsync(entity);
        return entity;
    }

    public async Task<Setup> GetByIdWithItemsAsync(Guid id)
    {
        var result = await _dbContext.Setups
            .Include(x => x.User)
            .Include(x => x.Items)
            .ThenInclude(z => z.Defects)
            .Include(x => x.Items)
            .ThenInclude(z => z.Room)
            .FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<List<SetupsListWithNumberOfDefects>> GetAllWithNumberOfDefects()
    {
        var setups = _dbContext.Setups
            .Select(x => new SetupsListWithNumberOfDefects()
            {
                Id = x.Id,
                SetupName = x.SetupName,
                Status = x.Status,
                UserId = x.UserId,
                NumberOfDefects = x.Items.SelectMany(z => z.Defects).Count()
            }).ToListAsync();
        return await setups;
    }
    
    public async Task<List<SetupsListWithNumberOfDefects>> GetByIdWithSetups(Guid id)
    {
        var room = await _dbContext.Rooms.FindAsync(id);
        if (room is null)
            throw new Exception("Room is not found");

        var setupsForRoom = await _dbContext.Rooms
            .Where(x => x.Id == room.Id)
            .Include(x => x.Items)
            .ThenInclude(x => x.Defects)
            .Include(x => x.Items)
            .ThenInclude(x => x.Setup)
            .ThenInclude(z => z.User)
            .ToListAsync();
        
        var setupsList = setupsForRoom
            .SelectMany(x => x.Items.Where(w=>w.SetupId != null).Select(z => z.Setup))
            .Distinct().ToList();
        
        var mappedSetupList = setupsList.Select(x => new SetupsListWithNumberOfDefects()
        {
            Id = x.Id,
            SetupName = x.SetupName,
            Status = x.Status,
            UserId = x.UserId,
            NumberOfDefects = x.Items.SelectMany(z => z.Defects).Count(),
            FullName = (x.User != null) ? x.User.FirstName + " " + x.User.LastName : "",
        }).ToList();
        

        return mappedSetupList;
    }

    public async Task<List<SetupsListForSelect>> GetAllSetupsForSelect()
    {
        var setups = _dbContext.Setups
            .Select(x => new SetupsListForSelect()
            {
                Id = x.Id,
                SetupName = x.SetupName,
                Status = x.Status,
                Items = x.Items.Select(z => new ListItemsForSetupSelect()
                {
                    Id = z.Id,
                    SetupId = z.SetupId
                }).ToList()
            }).ToListAsync();
        return await setups;
    }
}