using Microsoft.AspNetCore.Http.HttpResults;
using SimpleCrud.Application;
using SimpleCrud.Core;
using SimpleCrud.Infrastructure;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseInfrastructure();
app.Run();
