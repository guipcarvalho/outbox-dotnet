using MassTransit;
using Microsoft.EntityFrameworkCore;
using Ordering.Data;
using Ordering.Data.Repositories;
using Ordering.Data.Repositories.Contracts;
using Ordering.Events;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ApplicationContext>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IOutboxRepository, OutboxRepository>();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMassTransit(opt => { 
    opt.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});

builder.Services.AddHostedService<OutboxBackgroundService>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
await context.Database.MigrateAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
