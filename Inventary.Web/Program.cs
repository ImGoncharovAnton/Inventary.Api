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
using Inventary.Web.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("connectSql")));

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(o => o
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed((host) => true)
    .AllowCredentials());

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();



app.MapControllers();

app.Run();