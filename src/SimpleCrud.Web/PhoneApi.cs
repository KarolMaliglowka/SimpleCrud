using SimpleCrud.Core.Entities;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Web;

public static class PhoneApi
{
    public static WebApplication UsePhoneApi(this WebApplication app)
    {
        app
            .MapGet("api/phones/",
                async (IPhoneBookRepository phoneBookRepository) =>
                {
                    var results = await phoneBookRepository.GetAllAsync();
                    return Results.Ok(results);
                });
        app
            .MapGet("api/phones/{id:guid}",
            async (IPhoneBookRepository phoneBookRepository, Guid id) =>
            {
                var results = await phoneBookRepository.GetAsyncById(id);
                return Results.Ok(results);
                
            });
        app
            .MapPost("api/phones/",
                async (IPhoneBookRepository phoneBookRepository, PhoneBook phoneBook) =>
                {
                    await phoneBookRepository.AddAsync(phoneBook);
                    return Results.Ok();
                });
        app
            .MapPut("api/phones/",
                async (IPhoneBookRepository phoneBookRepository, PhoneBook phoneBook) =>
                {
                    await phoneBookRepository.UpdateAsync(phoneBook);
                    return Results.Ok();
                });
        app
            .MapDelete("api/phones/{id:guid}",
                async (IPhoneBookRepository phoneBookRepository, Guid id) =>
                {
                    await phoneBookRepository.Remove(id);
                    return Results.Ok();
                });

        return app;
    }
}