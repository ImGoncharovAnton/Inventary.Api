using Inventary.Repositories;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Infrastructure;
using Inventary.Tests.MockData;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inventary.Tests;

public class DependencyUserFixture
{
    public DependencyUserFixture()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseInMemoryDatabase(databaseName: "TestUsersDb");
        });
        serviceCollection.AddScoped<IRepositoryManager, RepositoryManager>();
        serviceCollection.AddScoped<IServiceManager, ServiceManager>();
        serviceCollection.AddTransient<ExceptionHandlerMiddleware>();
        serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        serviceCollection.AddAutoMapper(typeof(AppDomain));

        ServiceProvider = serviceCollection.BuildServiceProvider();
        using var scope = ServiceProvider.CreateScope();

        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
        // need or not, im not understand
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        
        context.Categories.AddRange(CategoryMockData.GetCategories());
        context.Setups.AddRange(SetupMockData.GetSetups());
        context.Items.AddRange(ItemMockData.GetItems());
        context.Rooms.AddRange(RoomMockData.GetRooms());
        context.Users.AddRange(UserMockData.GetUsers());
        context.SaveChanges();

    }
    public ServiceProvider ServiceProvider { get; private set; }
   
}