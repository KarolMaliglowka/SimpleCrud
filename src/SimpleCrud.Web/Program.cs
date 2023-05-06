using SimpleCrud.Application;
using SimpleCrud.Infrastructure;
using SimpleCrud.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure()
    .AddApplication();

var app = builder
    .Build()
    .UsePhoneApi();

app.Run();
