using Inventary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Repositories;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        :base(options)
    {
        
    }
    
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }
    // public DbSet<Category> Categories { get; set; }
    // public DbSet<Item> Items { get; set; }
    // public DbSet<Setup> Setups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        // modelBuilder.Entity<Setup>()
        //     .HasOne<User>(s => s.User)
        //     .WithOne(x => x.Setup)
        //     .HasForeignKey<User>(u => u.SetupId);
    }
}