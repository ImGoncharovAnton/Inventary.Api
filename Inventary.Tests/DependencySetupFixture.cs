using AutoFixture;
using Inventary.Domain.Entities;
using Inventary.Repositories;
using Inventary.Repositories.Infrastructure;
using Inventary.Services.Infrastructure;
using Inventary.Tests.MockData;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inventary.Tests;

public class DependencySetupFixture
{
    public DependencySetupFixture()
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
        var fixture = new Fixture();
        var categoryList = fixture.Build<Category>()
            .Without(x => x.Items)
            .CreateMany(5)
            .ToList();

        var categories = CategoryMockData.GetCategories();
        var setups = SetupMockData.GetSetups();
        
        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
        context.Categories.AddRange(categories);
        context.Setups.AddRange(setups);
        context.SaveChanges();

    }
    public ServiceProvider ServiceProvider { get; private set; }
   
}