using Inventary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Web;

public static class Extensions
{
    public static IHost MigrateDatabase(this IHost host)
    {
        // Manually run any pending migrations if configured to do so.
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        if (env == "Production")
        {
            var serviceScopeFactory = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));
            
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }
        }
        return host;
    }
}