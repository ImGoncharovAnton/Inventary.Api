using Inventary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inventary.Web;

public static class Extensions
{
    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder iApplicationBuilder)
    {
        // Manually run any pending migrations if configured to do so.
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        
            var serviceScopeFactory = (IServiceScopeFactory)iApplicationBuilder.ApplicationServices.GetService(typeof(IServiceScopeFactory));
            
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }
      
        return iApplicationBuilder;
    }
}