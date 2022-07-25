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
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    // public DbSet<Setup> Setups { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Defect> Defects { get; set; }
    public DbSet<DefectPhoto> DefectPhotos { get; set; }
    public DbSet<ItemPhoto> ItemPhotos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        // modelBuilder.Entity<Setup>()
        //     .HasOne<User>(s => s.User)
        //     .WithOne(x => x.Setup)
        //     .HasForeignKey<User>(u => u.SetupId);
        modelBuilder.Entity<Category>()
            .HasMany<Item>(x => x.Items)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CurrentCategoryId)
            .OnDelete(DeleteBehavior.SetNull);
        // modelBuilder.Entity<Item>()
        //     .HasMany<ItemPhoto>(x => x.ItemPhotos)
        //     .WithOne(x => x.Item)
        //     .HasForeignKey(x => x.ItemId);
        // modelBuilder.Entity<ItemPhoto>().Property(b => b.ItemId).UseIdentityColumn();
    }
}