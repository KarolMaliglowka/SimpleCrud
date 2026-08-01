using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Application.Dtos;
using SimpleCrud.Application.Services;
using SimpleCrud.Core.Entities;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Api;

public static class PhoneEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.MapGet("", async (IPhoneBookRepository phoneBookRepository, IPhoneService phoneService) =>
        {
            var getAllAsync = await phoneService.GetAllPhones();
            return getAllAsync.Count != 0
                ? Results.Ok(getAllAsync)
                : Results.NotFound("No records in database :/");
        });

        app.MapGet("getById/{phoneId:guid}", async (IPhoneBookRepository phoneBookRepository, Guid phoneId) =>
        {
            //przenieść do Services w Application i zmienić na wspólny kod REST i SOAP
            var phone = await phoneBookRepository
                .GetAsyncById(phoneId);
            return phone != null
                ? Results.Ok(new PhoneDto
                {
                    Id = phone.Id,
                    Name = phone.Name,
                    PhoneNumber = phone.PhoneNumber,
                    Description = phone.Description
                })
                : Results.NotFound("No record in database :/");
        });

        app.MapGet("getByPhoneNumber/{phoneNumber}",
            async (IPhoneBookRepository phoneBookRepository, string phoneNumber) =>
            {
                //przenieść do Services w Application i zmienić na wspólny kod REST i SOAP
                var phone = await phoneBookRepository.GetAsyncByPhoneNumber(phoneNumber);
                return phone != null
                    ? Results.Ok(new PhoneDto
                    {
                        Id = phone.Id,
                        Name = phone.Name,
                        PhoneNumber = phone.PhoneNumber,
                        Description = phone.Description
                    })
                    : Results.NotFound("No record in database :/");
            });

        app.MapGet("getByPhoneName/{phoneName}", async (IPhoneBookRepository phoneBookRepository, string phoneName) =>
        {
            //przenieść do Services w Application i zmienić na wspólny kod REST i SOAP
            var phone = await phoneBookRepository.GetAsyncByPhoneName(phoneName);
            return phone != null
                ? Results.Ok(new PhoneDto
                {
                    Id = phone.Id,
                    Name = phone.Name,
                    PhoneNumber = phone.PhoneNumber,
                    Description = phone.Description
                })
                : Results.NotFound("No record in database :/");
        });

        app.MapPost("create", async (IPhoneBookRepository phoneBookRepository, [FromBody] PhoneDto command) =>
        {
            //przenieść do Services w Application i zmienić na wspólny kod REST i SOAP
            var newPhone = new PhoneBook(command.PhoneNumber, command.Name, command.Description);
            await phoneBookRepository.AddAsync(newPhone);
            return Results.Created();
        });

        app.MapPatch("update", async (IPhoneBookRepository phoneBookRepository, [FromBody] PhoneDto command) =>
        {
            //przenieść do Services w Application i zmienić na wspólny kod REST i SOAP
            var phone = await phoneBookRepository.GetAsyncById(command.Id);
            if (phone == null)
            {
                return Results.NotFound("No record in database :/");
            }

            phone.SetPhoneNumber(command.PhoneNumber);
            phone.SetName(command.Name);
            phone.SetDescription(command.Description);
            await phoneBookRepository.Update(phone);
            return Results.Ok();
        });

        app.MapDelete("delete/{phoneId:guid}", async (IPhoneBookRepository phoneBookRepository, Guid phoneId) =>
        {
            //przenieść do Services w Application i zmienić na wspólny kod REST i SOAP
            var phone = await phoneBookRepository.GetAsyncById(phoneId);
            if (phone == null)
            {
                return Results.NotFound("No record in database :/");
            }

            await phoneBookRepository.Remove(phone);
            return Results.Ok();
        });

        app.MapDelete("deleteMany", async (IPhoneBookRepository phoneBookRepository, IEnumerable<Guid> phoneIds) =>
        {
            //przenieść do Services w Application i zmienić na wspólny kod REST i SOAP
            var phone = await phoneBookRepository.GetAllAsync();
            var phonesToDelete = phone
                .Where(p =>
                    phoneIds.Any(ids => ids == p.Id));
            var phoneBooks = phonesToDelete.ToList();
            if (phoneBooks.Count == 0)
            {
                return Results.NotFound("No records in database :/");
            }

            await phoneBookRepository.RemoveMany(phoneBooks);
            return Results.Ok();
        });
    }
}