using System.Text.Json.Serialization;
using AutoMapper;
using Inventary.Repositories;
using Inventary.Repositories.Contracts;
using Inventary.Repositories.Infrastructure;
using Inventary.Repositories.Repositories;
using Inventary.Services.Contracts;
using Inventary.Services.Infrastructure;
using Inventary.Services.Mappers;
using Inventary.Services.Services;
using Inventary.Web;
using Inventary.Web.Middleware;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    string connStr;
    
    // Depending on if in development or production, use either Heroku-provided
    // connection string, or development connection string from env var.
    if (env == "Development")
    {
        // Use connection string from file.
        connStr = configuration.GetConnectionString("connectSql");
    }
    else
    {
        // Use connection string provided at runtime by Heroku.
        var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
        // Parse connection URL to connection string for Npgsql
        connUrl = connUrl.Replace("postgres://", string.Empty);
        var pgUserPass = connUrl.Split("@")[0];
        var pgHostPortDb = connUrl.Split("@")[1];
        var pgHostPort = pgHostPortDb.Split("/")[0];
        var pgDb = pgHostPortDb.Split("/")[1];
        var pgUser = pgUserPass.Split(":")[0];
        var pgPass = pgUserPass.Split(":")[1];
        var pgHost = pgHostPort.Split(":")[0];
        var pgPort = pgHostPort.Split(":")[1];
        connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};sslmode=Require;TrustServerCertificate=True";
    }
    // Whether the connection string came from the local development configuration file
    // or from the environment variable from Heroku, use it to set up your DbContext.
    options.UseNpgsql(connStr, x => 
        x.MigrationsHistoryTable("__efmigrationshistory", "public"))
        .UseSnakeCaseNamingConvention()
        .ReplaceService<IHistoryRepository, LoweredCaseMigrationHistoryRepository>();
    
});

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();


// this needed for ignore cyclic json objects
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers().AddJsonOptions(x => 
    x.JsonSerializerOptions.AllowTrailingCommas = true);

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(AppDomain));
builder.Services.AddAutoMapper(typeof(RoomsDtoProfile).Assembly);

var app = builder.Build();


app.UseForwardedHeaders(new ForwardedHeadersOptions()
{
    ForwardedHeaders = ForwardedHeaders.XForwardedProto
});
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(o => o
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(origin  => true)
    .AllowCredentials());

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MigrateDatabase();
app.Run();