using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Application.Dtos;
using SimpleCrud.Application.Services;

namespace SimpleCrud.Api.EndPoints;

public static class PhoneEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.MapGet("", async (IPhoneService phoneService) =>
        {
            var getAllAsync = await phoneService.GetAllPhones();
            return getAllAsync.Count != 0
                ? Results.Ok(getAllAsync)
                : Results.NotFound("No records in database :/");
        });

        app.MapGet("getById/{phoneId:guid}", async (IPhoneService phoneService, Guid phoneId) =>
        {
            var phone = await phoneService.GetById(phoneId);
            return phone != null
                ? Results.Ok(phone)
                : Results.NotFound("No record in database :/");
        });

        app.MapGet("getByPhoneNumber/{phoneNumber}",
            async (IPhoneService phoneService, string phoneNumber) =>
            {
                var phone = await phoneService.GetByNumber(phoneNumber);
                return phone != null
                    ? Results.Ok(phone)
                    : Results.NotFound("No record in database :/");
            });

        app.MapGet("getByPhoneName/{phoneName}", async (IPhoneService phoneService, string phoneName) =>
        {
            var phone = await phoneService.GetByName(phoneName);
            return phone != null
                ? Results.Ok(phone)
                : Results.NotFound("No record in database :/");
        });

        app.MapPost("create", async (IPhoneService phoneService, [FromBody] PhoneDto command) =>
        {
            var result = await phoneService.AddPhone(command);
            return Results.Created($"getById/{result}", result);
        });

        app.MapPatch("update", async (IPhoneService phoneService, [FromBody] PhoneDto command) =>
        {
            await phoneService.UpdatePhone(command);
            return Results.Ok();
        });

        app.MapDelete("delete/{phoneId:guid}", async (IPhoneService phoneService, Guid phoneId) =>
        {
            await phoneService.DeletePhone(phoneId);
            return Results.Ok();
        });

        app.MapDelete("deleteMany", async (IPhoneService phoneService, IEnumerable<Guid> phoneIds) =>
        {
            await phoneService.DeleteManyPhones(phoneIds);
            return Results.Ok();
        });
    }
}