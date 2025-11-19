using Application;
using Application.Abstraction.AppConfig;
using Infrastructure;
using Microsoft.OpenApi.Models;
using NoSqlService.DependencyInjection;
using NoSqlService.Persistance.DbContext;
using Persistance;
using Persistance.EF.DBContext;
using System.Text.Json.Serialization;
using WebApi.Filters;
using WebApi.Others;
using Seed = Domain.Concrete;

var builder = WebApplication.CreateBuilder(args);

var mongoConnection = builder.Configuration.GetConnectionString("DefaultNoSql");
var mongoDbName = builder.Configuration["Mongo:Database:Name"];

builder.Services.RegisterServicesFromNoSqlService(mongoConnection, mongoDbName);

// Add services to the container.

builder.Services.AddControllers(option =>
{
    option.Filters.Add(typeof(AuthenticationFilter), 2);
    option.Filters.Add(typeof(ModelStateFilterAttribute), 3);
    option.Filters.Add(typeof(ExceptionHandlingFilter), 1);
});

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MedoraApp.Api",
        Version = "v1"
    });
    c.OperationFilter<SwaggerAddAuthenticationHeaderFilter>();
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddScoped<IExceptionHandler, ExceptionHandler>();

builder.Services.SetDbConfiguration(builder.Configuration);
builder.Services.RegisterServicesFromApplication(builder.Configuration);
builder.Services.RegisterServicesFromPersistance(builder.Configuration);
builder.Services.RegisterServicesFromInfrastructure(builder.Configuration);

var app = builder.Build();

DbInitializer.Seed(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
