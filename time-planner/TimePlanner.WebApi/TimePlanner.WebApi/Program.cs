using TimePlanner.Domain.Interfaces;
using Serilog;
using TimePlanner.WebApi;
using TimePlanner.Infrastructure.Repositories;
using TimePlanner.Domain.Services;
using Microsoft.EntityFrameworkCore;
using TimePlanner.Infrastructure.EFCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IGoalCategoriesRepository, GoalsCategoriesRepository>();
builder.Services.AddScoped<IGoalsRepository, GoalsRepository>();
builder.Services.AddScoped<IGoalsService, GoalsService>();
builder.Services.AddScoped<IGoalsPeriodsRepository, GoalsPeriodsRepository>();
builder.Services.AddSingleton<ExceptionMiddleware>();
builder.Services.AddDbContext<GoalsContext>(
    options => options.UseSqlServer("name=ConnectionStrings:MainConnectionString"));

var app = builder.Build();
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.RollingFile("test")
    .CreateLogger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
