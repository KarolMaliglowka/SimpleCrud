using Microsoft.EntityFrameworkCore;
using SimpleCrud.Application;
using SimpleCrud.Infrastructure;
using SimpleCrud.Infrastructure.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy",
    corsPolicyBuilder =>
    {
        corsPolicyBuilder
            .WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("ApiCorsPolicy");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
ApplyMigration();
app.Run();
return;

void ApplyMigration()
{
    using var scope = app.Services.CreateScope();
    var db=scope.ServiceProvider.GetRequiredService<SimpleCrudDbContext>();
    if(db.Database.GetPendingMigrations().Any())
    {
        db.Database.Migrate();
    }
}