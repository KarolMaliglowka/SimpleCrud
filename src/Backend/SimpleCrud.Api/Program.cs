using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using SimpleCrud.Api.EndPoints;
using SimpleCrud.Api.WCF;
using SimpleCrud.Application;
using SimpleCrud.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddOpenApi();

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddScoped<PhoneSoapService>();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

var serviceMetadataBehavior = app.Services
    .GetRequiredService<ServiceMetadataBehavior>();

serviceMetadataBehavior.HttpGetEnabled = true;

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<PhoneSoapService>();

    serviceBuilder.AddServiceEndpoint<PhoneSoapService, IPhoneSoapContract>(
        new BasicHttpBinding(),
        "/PhoneService");
});

app.UseCors("AllowAngular");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapBookEndpoints();

app.UseHttpsRedirection();

app.Run();