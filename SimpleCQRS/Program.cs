using MediatR;
using Microsoft.AspNetCore.Hosting;
using SimpleCQRS.Behaviors;
using SimpleCQRS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Mediatr

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

// Add services to the container.

builder.Services.AddControllers();

//Add Service as DI

builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>) ,typeof(LoginBehavior<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
