using SimpleCrud.Application.Dtos;
using SimpleCrud.Core.Entities;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Api;

public static class BookEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.MapGet("", async (IPhoneBookRepository phoneBookRepository) =>
        {
            var getAllAsync = (await phoneBookRepository
                    .GetAllAsync())
                .ToList();
            return Results.Ok(getAllAsync.ToList());
        });
        
        app.MapGet("getById/{phoneId:guid}", async (IPhoneBookRepository phoneBookRepository, Guid phoneId) =>
        {
            var phone = await phoneBookRepository
                .GetAsyncById(phoneId);
            if (phone == null)
            {
                throw new NullReferenceException("No record in database :/");
            }

            return Results.Ok(new PhoneDto
            {
                Id = phone.Id,
                Name = phone.Name,
                PhoneNumber = phone.PhoneNumber
            });
        });
        
        app.MapGet("getByPhoneNumber/{phoneNumber}", async (IPhoneBookRepository phoneBookRepository, string phoneNumber) =>
        {
            var phone = await phoneBookRepository.GetAsyncByPhoneNumber(phoneNumber);
            if (phone == null)
            {
                throw new NullReferenceException("No record in database :/");
            }

            return Results.Ok(new PhoneDto
            {
                Id = phone.Id,
                Name = phone.Name,
                PhoneNumber = phone.PhoneNumber
            });
        });
        
        app.MapGet("getByPhoneName/{phoneName}", async (IPhoneBookRepository phoneBookRepository, string phoneName) =>
        {
            var phone = await phoneBookRepository.GetAsyncByPhoneName(phoneName);
            if (phone == null)
            {
                throw new NullReferenceException("No record in database :/");
            }

            return Results.Ok(new PhoneDto
            {
                Id = phone.Id,
                Name = phone.Name,
                PhoneNumber = phone.PhoneNumber
            });
        });

        app.MapPost("create", async (IPhoneBookRepository phoneBookRepository, PhoneDto command) =>
        {
            var newPhone = new PhoneBook(command.PhoneNumber, command.Name);
            await phoneBookRepository.AddAsync(newPhone);
            return Results.Created();
        });

        app.MapPatch("update", async (IPhoneBookRepository phoneBookRepository, PhoneDto command) =>
        {
            var phone = await phoneBookRepository.GetAsyncById(command.Id);
            if (phone == null)
            {
                throw new NullReferenceException("No record in database :/");
            }
            phone.SetPhoneNumber(command.PhoneNumber);
            phone.SetName(command.Name);
            await phoneBookRepository.Update(phone);
            return Results.Ok();
        });
        
        app.MapDelete("delete/{phoneId:guid}", async (IPhoneBookRepository phoneBookRepository, Guid phoneId) =>
        {
            var phone = await phoneBookRepository.GetAsyncById(phoneId);
            if (phone == null)
            {
                throw new NullReferenceException("No record in database :/");
            }

            await phoneBookRepository.Remove(phone);
            return Results.Ok();
        });
        
        app.MapDelete("deleteMany", async (IPhoneBookRepository phoneBookRepository, IEnumerable<Guid> phoneIds) =>
        {
            var phone = await phoneBookRepository.GetAllAsync();
            var phonesToDelete = phone
                .Where(p =>
                    phoneIds.Any(ids => ids == p.Id));
            var phoneBooks = phonesToDelete.ToList();
            if (phoneBooks.Count == 0)
            {
                throw new NullReferenceException("No records in database :/");
            }

            await phoneBookRepository.RemoveMany(phoneBooks);
            return Results.Ok();
        });
    }
}