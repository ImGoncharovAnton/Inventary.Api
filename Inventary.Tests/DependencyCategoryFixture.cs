using Inventary.Repositories;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Infrastructure;
using Inventary.Tests.MockData;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inventary.Tests;

public class DependencyCategoryFixture
{
    public DependencyCategoryFixture()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseInMemoryDatabase(databaseName: "TestDb");
        });
        serviceCollection.AddScoped<IRepositoryManager, RepositoryManager>();
        serviceCollection.AddScoped<IServiceManager, ServiceManager>();
        serviceCollection.AddTransient<ExceptionHandlerMiddleware>();
        serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        serviceCollection.AddAutoMapper(typeof(AppDomain));

        ServiceProvider = serviceCollection.BuildServiceProvider();
        using var scope = ServiceProvider.CreateScope();
        var categories = CategoryMockData.GetCategories();
        var setups = SetupMockData.GetSetups();

        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
        // need or not, im not understand
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        
        context.Categories.AddRange(categories);
        context.Setups.AddRange(setups);
        context.SaveChanges();

    }
    public ServiceProvider ServiceProvider { get; private set; }
   
}