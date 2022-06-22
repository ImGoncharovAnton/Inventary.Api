using Inventary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Repositories;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        :base(options)
    {
        
    }

    // private DbSet<RoomEntity> Rooms { get; set; }
    public DbSet<RoomEntity> Rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}